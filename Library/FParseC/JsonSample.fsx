#r "nuget: FsUnit"
open FsUnit
#r "nuget: FParsec"
open FParsec

module JsonSample03 =
  """
  attempt版
  <|> 演算子は効率を重視してデフォルトの挙動が入力を巻き戻さないようになっている.
  attempt をやみくもに使うのはよくない.
  """
  let jnumber3 s = s |> (attempt jfloat <|> jinteger)
  "1"   |> parseBy jnumber3 |> should equal (JInteger 1)
  "2.0" |> parseBy jnumber3 |> should equal (JFloat 2.0)

  """
  attemptを使わないバージョン
  """
  let jnumber4 s =
    s |> (tuple3 minusSign integer (opt (pchar '.' >>. integer))
          |>> (function
               | (hasMinus, i, None) -> JInteger (if hasMinus then -i else i)
               | (hasMinus, i, Some flac) ->
               let f = float i + float ("0." + string flac)
               JFloat (if hasMinus then -f else f)))
  "1"   |> parseBy jnumber4 |> should equal (JInteger 1)
  "2.0" |> parseBy jnumber4 |> should equal (JFloat 2.0)

module JsonSample04 =
  """
  同じプレフィックス(今回の場合整数部)を持つ選択肢が3つ以上だと opt では解決できない.
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

  let minusSign s = s |> (opt (pchar '-') |>> Option.isSome)
  let digit1to9 s = s |> (anyOf ['1'..'9'])
  let integer s = s |> ((many1Chars2 digit1to9 digit <|> pstring "0") |>> int)
  let jinteger s =
    s |> (minusSign .>>. integer
          |>> (fun (hasMinus, x) -> JInteger (if hasMinus then -x else x)))
  // choice [p1; p2; ...; pn] は、 p1 <|> p2 <|> ... <|> pn と同じ意味で、高速
  let jnum s =
    s |> (choice [ pchar '.' >>. integer |>> (fun frac i -> JFloat (float i + float ("0." + string frac)));
                   pchar '/' >>. integer |>> (fun d n -> JRational (n, d));
                   preturn JInteger ]) // preturnは、常に成功し、引数に指定した結果を返すパーサーを返す関数
  let jnumber s =
    s |> (tuple3 minusSign integer jnum
          |>> (fun (hasMinus, i, f) -> f (if hasMinus then -i else i)))

  "1"   |> parseBy jnumber |> should equal (JInteger 1)
  "2.0" |> parseBy jnumber |> should equal (JFloat 2.0)
  "3/4" |> parseBy jnumber |> should equal (JRational (3,4))

module JsonSample05 =
  """
  再帰文法: 配列はネストできるのでネストさせたい.
  createParserForwardedToRefをうまく使う.

  旧jarray
  let jarray s =
    s |> (sepBy jnumber (pchar ',' >>. ws)
          |> between (pchar '[' >>. ws) (pchar ']' >>. ws)
          |>> JArray)
  """

  let nonEscapedChar s = s |> noneOf ['\\'; '"']
  let convEsc = function
    | 'b' -> '\b'
    | 'f' -> '\f'
    | 'n' -> '\n'
    | 'r' -> '\r'
    | 't' -> '\t'
    | c -> c      // '\\', '"', '/' はそのまま使う
  let escapedChar s = s |> (pchar '\\' >>. anyOf @"\""/bfnrt" |>> convEsc)
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
  jarrayRef :=
    // 再帰したい場合は、 !jarrayRef ではなく、 jarray を使う
    sepBy (choice [jnumber; jstring; jarray]) (pchar ',' >>. ws)
    |> between (pchar '[' >>. ws) (pchar ']' >>. ws)
    |>> JArray

"""TODO: https://tyrrrz.me/blog/parsing-with-fparsec"""
