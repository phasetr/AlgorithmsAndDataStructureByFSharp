#r "nuget: FsUnit"
open FsUnit
#r "nuget: FParsec"
open FParsec

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
