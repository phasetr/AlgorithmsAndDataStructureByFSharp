@"https://bleis-tift.hatenablog.com/entry/json-parser-using-fparsec"

#r "nuget: FsUnit"
open FsUnit
#r "nuget: FParsec"
open FParsec

"""
再帰文法: 配列はネストできるのでネストさせたい.
createParserForwardedToRefをうまく使う.

旧jarray
let jarray s =
  s |> (sepBy jnumber (pchar ',' >>. ws)
        |> between (pchar '[' >>. ws) (pchar ']' >>. ws)
        |>> JArray)
"""

type Json =
  | JInteger of int
  | JFloat of float
  | JRational of int * int // 有理数を追加
  | JString of string
  | JArray of Json list

let ws = spaces
let parseBy p str =
  match run (between ws eof p) str with
    | Success (res, _, _) -> res
    | Failure (msg, _, _) -> failwithf "parse error: %s" msg

// jnumberの定義を変更, 指数表記は未対応
let minusSign s = s |> (opt (pchar '-') |>> Option.isSome)
let digit1to9 s = s |> (anyOf ['1'..'9'])
let integer s = s |> ((many1Chars2 digit1to9 digit <|> pstring "0") |>> int)
// choice [p1; p2; ...; pn] は、 p1 <|> p2 <|> ... <|> pn と同じ意味で、高速
let jnum s =
  s |> (choice [ pchar '.' >>. integer |>> (fun frac i -> JFloat (float i + float ("0." + string frac)));
                 pchar '/' >>. integer |>> (fun d n -> JRational (n, d));
                 preturn JInteger ]) // preturnは、常に成功し、引数に指定した結果を返すパーサーを返す関数
let jnumber s =
  s |> (tuple3 minusSign integer jnum
        |>> (fun (hasMinus, i, f) -> f (if hasMinus then -i else i)))

let nonEscapedChar s = s |> noneOf ['\\'; '"']

let convEsc = function
  | 'b' -> '\b'
  | 'f' -> '\f'
  | 'n' -> '\n'
  | 'r' -> '\r'
  | 't' -> '\t'
  | c -> c      // '\\', '"', '/' はそのまま使う

let escapedChar s = s |> (pchar '\\' >>. anyOf @"\""/bfnrt" |>> convEsc)

/// エスケープ文字対応
let jstring s =
  s |> (manyChars (nonEscapedChar <|> escapedChar) // どちらかの繰り返し
        |> between (pchar '"') (pchar '"')
        .>> ws
        |>> JString)

"""
// jarrayの定義の中ではjarrayにアクセスできないのでコンパイルエラー
let jarray s =
  s |> (sepBy (choice [jnumber; jstring; jarray]) (pchar ',' >>. ws)
        |> between (pchar '[' >>. ws) (pchar ']' >>. ws)
        |>> JArray)
"""
// jarray は、 jarrayRef を見るようになっている
let jarray, jarrayRef: Parser<Json,unit> * Parser<Json,unit> ref = createParserForwardedToRef ()
// jarrayRef は ref 型なので、再代入できる
jarrayRef.Value <-
  // 再帰したい場合は、 !jarrayRef ではなく、 jarray を使う
  sepBy (choice [jnumber; jstring; jarray]) (pchar ',' >>. ws)
  |> between (pchar '[' >>. ws) (pchar ']' >>. ws)
  |>> JArray

let json, jsonRef: Parser<Json,unit> * Parser<Json,unit> ref = createParserForwardedToRef ()
let jarray =
  sepBy json (pchar ',' >>. ws)
  |> between (pchar '[' >>. ws) (pchar ']' >>. ws)
  |>> JArray
jsonRef.Value <- choice [jnumber; jstring; jarray]

let () =
  "[[], 1, \"aaa\"]" |> parseBy json |> should equal (JArray [JArray []; JInteger 1; JString "aaa"])
  "[[[]], 1, \"aaa\"]" |> parseBy json |> should equal (JArray [JArray [JArray []]; JInteger 1; JString "aaa"])

let () =
  /// 既存のテスト
  "1.5" |> parseBy pfloat |> should equal 1.5
  "1.5" |> parseBy jnumber |> should equal (JFloat 1.5)
  "1,2,3" |> parseBy (sepBy jnumber (pchar ',')) |> should equal [JInteger 1; JInteger 2; JInteger 3]
  "[1,2,3]" |> parseBy jarray |> should equal (JArray [JInteger 1; JInteger 2; JInteger 3])
  (fun () -> "[ 1, 2, 3 ]" |> parseBy jarray |> ignore) |> should throw typeof<System.Exception>

  @"\\"  |> parseBy escapedChar |> should equal '\\'
  @"\""" |> parseBy escapedChar |> should equal '"'
  "\"abc\""       |> parseBy jstring |> should equal (JString "abc")
  "\"abc\\ndef\"" |> parseBy jstring |> should equal (JString "abc\ndef")
  @"\n"  |> parseBy escapedChar |> should equal '\010' // 改行文字化

  // 基本的な要素のテスト
  "-2" |> parseBy (opt (pchar '-') .>>. digit) |> should equal (Some '-', '2')
  "1"  |> parseBy (opt (pchar '-') .>>. digit) |> should equal (None, '1')
  "1230" |> parseBy (many1Chars2 (anyOf ['1'..'9']) digit) |> should equal "1230"
  (fun () -> "0123" |> parseBy (many1Chars2 (anyOf ['1'..'9']) digit) |> ignore) |> should throw typeof<System.Exception>
  "1.2" |> parseBy (digit .>>. pchar '.' .>>. digit) |> should equal (('1', '.'), '2')
  "1.2" |> parseBy (tuple3 digit (pchar '.') digit)  |> should equal ('1', '.', '2')
  "1" |> parseBy jnumber |> should equal (JInteger 1)
  "2.0" |> parseBy jnumber |> should equal (JFloat 2.0)
  "1" |> parseBy jnumber |> should equal (JInteger 1)
  "1"   |> parseBy jnumber |> should equal (JInteger 1)
  "2.0" |> parseBy jnumber |> should equal (JFloat 2.0)
  "3/4" |> parseBy jnumber |> should equal (JRational (3,4))
