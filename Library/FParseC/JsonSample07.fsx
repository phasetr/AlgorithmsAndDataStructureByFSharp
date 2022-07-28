@"https://bleis-tift.hatenablog.com/entry/json-parser-using-fparsec"

#r "nuget: FsUnit"
open FsUnit
#r "nuget: FParsec"
open FParsec

"「選択されない選択肢」から"
type Json =
  //| JNumber of float
  | JInteger of int
  | JFloat of float
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
let jinteger s =
  s |> (minusSign .>>. integer
        |>> (fun (hasMinus, x) -> JInteger (if hasMinus then -x else x)))
let jfloat s =
  s |> (tuple3 minusSign integer (pchar '.' >>. integer)
        |>> (fun (hasMinus, i, flac) ->
             let f = float i + float ("0." + string flac)
             JFloat (if hasMinus then -f else f)))

"""定義の入れ替えでどうか?"""
let jnumber s = s |> (jfloat <|> jinteger)

let () =
  "2.0" |> parseBy jnumber |> should equal (JFloat 2.0)
  // エラー: <|> 演算子が左項のパーサーが失敗してもそのパーサーが消費した入力を戻さないことが原因
  (fun () -> "1" |> parseBy jnumber |> should equal (JInteger 1) |> ignore) |> should throw typeof<System.Exception>

let jarray s =
  s |> (sepBy jnumber (pchar ',' >>. ws)
        |> between (pchar '[' >>. ws) (pchar ']' >>. ws)
        |>> JArray)

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

let () =
  /// 既存のテスト
  "1.5" |> parseBy pfloat |> should equal 1.5
  // (fun () -> "1.5" |> parseBy jnumber |> ignore) |> should throw typeof<System.Exception>
  // 通るようになった
  "1.5" |> parseBy jnumber |> should equal (JFloat 1.5)
  /// 定義変更
  (fun () -> "1,2,3" |> parseBy (sepBy jnumber (pchar ',')) |> ignore) |> should throw typeof<System.Exception>
  (fun () -> "[1,2,3]" |> parseBy jarray |> ignore) |> should throw typeof<System.Exception>
  (fun () -> "[1,2,3]" |> parseBy jarray |> ignore) |> should throw typeof<System.Exception>
  (fun () -> "[ 1, 2, 3 ]" |> parseBy jarray |> ignore) |> should throw typeof<System.Exception>

  @"\\"  |> parseBy escapedChar |> should equal '\\'
  @"\""" |> parseBy escapedChar |> should equal '"'
  "\"abc\""       |> parseBy jstring |> should equal (JString "abc")
  "\"abc\\ndef\"" |> parseBy jstring |> should equal (JString "abc\ndef")
  @"\n"  |> parseBy escapedChar |> should equal '\010' // 改行文字化

  """基本的な要素のテスト"""
  "-2" |> parseBy (opt (pchar '-') .>>. digit) |> should equal (Some '-', '2')
  "1"  |> parseBy (opt (pchar '-') .>>. digit) |> should equal (None, '1')
  "1230" |> parseBy (many1Chars2 (anyOf ['1'..'9']) digit) |> should equal "1230"
  (fun () -> "0123" |> parseBy (many1Chars2 (anyOf ['1'..'9']) digit) |> ignore) |> should throw typeof<System.Exception>
  "1.2" |> parseBy (digit .>>. pchar '.' .>>. digit) |> should equal (('1', '.'), '2')
  "1.2" |> parseBy (tuple3 digit (pchar '.') digit)  |> should equal ('1', '.', '2')
  (fun () -> "1" |> parseBy jnumber |> should equal (JInteger 1) |> ignore) |> should throw typeof<System.Exception>
  "2.0" |> parseBy jnumber |> should equal (JFloat 2.0)
