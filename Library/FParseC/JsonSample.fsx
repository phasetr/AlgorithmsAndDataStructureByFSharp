#r "nuget: FsUnit"
open FsUnit
#r "nuget: FParsec"
open FParsec

@"https://bleis-tift.hatenablog.com/entry/json-parser-using-fparsec"
module PartsSample =
  module SymbolsSample =
    """<|>"""
    "a" |> parseBy (pchar 'a' <|> pchar 'b') |> should equal 'a'
    "b" |> parseBy (pchar 'a' <|> pchar 'b') |> should equal 'b'

  module AnyofSample =
    """
    noneOf の逆.
    引数で指定された seq<char> のうちの1文字をパースするパーサーを返す.
    """
    "a" |> parseBy (anyOf "abc") |> should equal 'a'
    "c" |> parseBy (anyOf "abc") |> should equal 'c'
    """
    エラー
    "z" |> parseBy (anyOf "abc")
    """

  module DotSample =
    let hi s =
      s |> (pchar 'h' .>>. pchar 'i'
            |>> (fun (h, i) -> string h + string i)) // 結果はタプルとして渡される
    let hi2 s =
      s |> (pchar 'h' .>> pchar 'i'  // pchar 'i' の結果は捨てる
            |>> (fun h -> string h)) // 捨てたので結果に含まれない
    let hi3 s =
      s |> (pchar 'h' >>. pchar 'i'  // pchar 'h' の結果は捨てる
            |>> (fun i -> string i)) // 捨てたので結果に含まれない

    "hi" |> parseBy hi  |> should equal "hi"
    "hi" |> parseBy hi2 |> should equal "h"
    "hi" |> parseBy hi3 |> should equal "i"

    """
    捨てるとは言ってもパースしないわけではないので,
    後続のパーサーが失敗すると全体として失敗する.
    "ho" |> parseBy hi2 // => エラー
    """

  module ManyCharsSample =
    "abc" |> parseBy (manyChars (noneOf "xyz")) |> should equal "abc"
    """
    エラー
    "axc" |> parseBy (manyChars (noneOf "xyz"))
    """

  module NoneofSample =
    """string は seq<char> でもあるので、 ['x'; 'y'; 'z'] の代わりに "xyz" と書いてもOK"""
    "a" |> parseBy (noneOf "xyz") |> should equal 'a'

    """
    エラー
    "y" |> parseBy (noneOf "xyz")
    """


@"https://bleis-tift.hatenablog.com/entry/json-parser-using-fparsec"
module JsonSample01 =
  type Json =
    | JNumber of float    // F#のfloatは64bit
    | JArray of Json list // F#では配列よりもlistの方が扱いやすい

  module Parser01 =
    let parseBy p str =
      // run関数はFParsecが用意している、パーサーを実行するための関数
      match run p str with
        | Success (res, _, _) -> res
        | Failure (msg, _, _) -> failwithf "parse error: %s" msg

    "1.5" |> parseBy pfloat |> should equal 1.5

    // これがパーサー
    let jnumber n = n |> (pfloat |>> (fun x -> JNumber x))

    "1.5" |> parseBy jnumber |> should equal (JNumber 1.5)
    "1,2,3" |> parseBy (sepBy jnumber (pchar ',')) |> should equal [JNumber 1.0; JNumber 2.0; JNumber 3.0]

    // これがパーサー
    let jarray s =
      s |> (sepBy jnumber (pchar ',')
            |> between (pchar '[') (pchar ']')
            |>> (fun xs -> JArray xs))

    "[1,2,3]" |> parseBy jarray |> should equal (JArray [JNumber 1.0; JNumber 2.0; JNumber 3.0])
    """
    以下はエラー
    "[ 1, 2, 3 ]" |> parseBy jarray
    """

  module Parser02 =
    """FParseCはトークン列が扱えないため, レキサーの仕事もパーサーで捌く.
    空白のスキップを下手に書くと繰り返しや再帰と組み合わさった際に簡単に無限ループに陥いる.
    空白スキップの戦略を決めるとよく,
    例えば各パーサーの「後ろの空白」を読み飛ばし,
    最後に全体のパーサーの「前の空白」を読み飛ばせば空白がスキップできる.
    """
    let ws = spaces
    let jnumber s = s |> (pfloat .>> ws |>> JNumber)
    let jarray s =
      s |> (sepBy jnumber (pchar ',' >>. ws)
            |> between (pchar '[' >>. ws) (pchar ']' >>. ws)
            |>> JArray)

    let parseBy p str =
      match run (ws >>. p) str with
        | Success (res, _, _) -> res
        | Failure (msg, _, _) -> failwithf "parse error: %s" msg

    "[ 1, 2, 3 ]" |> parseBy jarray |> should equal (JArray [JNumber 1.0; JNumber 2.0; JNumber 3.0])
    // 嫌な例: 前方一致のため
    "[1, 2, 3]]]]" |> parseBy jarray |> should equal (JArray [JNumber 1.0; JNumber 2.0; JNumber 3.0])

    let parseBy2 p str =
      match run (ws >>. p .>> eof) str with
        | Success (res, _, _) -> res
        | Failure (msg, _, _) -> failwithf "parse error: %s" msg

    "[ 1, 2, 3 ]" |> parseBy2 jarray |> should equal (JArray [JNumber 1.0; JNumber 2.0; JNumber 3.0])
    """
    エラー
    "[1, 2, 3]]]]" |> parseBy2 jarray |> should equal (JArray [JNumber 1.0; JNumber 2.0; JNumber 3.0])
    """

module JsonSample01 =
  type Json =
    | JNumber of float
    | JString of string
    | JArray of Json list

  let ws = spaces
  let jnumber s = s |> (pfloat .>> ws |>> JNumber)
  let jarray s =
    s |> (sepBy jnumber (pchar ',' >>. ws)
          |> between (pchar '[' >>. ws) (pchar ']' >>. ws)
          |>> JArray)

  """エスケープ非対応"""
  let jstring1 s =
    s |> (manyChars (noneOf ['"'])
          |> between (pchar '"') (pchar '"')
          .>> ws
          |>> JString)

  let nonEscapedChar s = s |> noneOf ['\\'; '"']

  """
  エスケープされた文字を考える: ただし`\uxxxx`形式は除く.
  エスケープされた文字は「開始文字()から始まりエスケープシーケンスの種類を表す文字が続く」.
  """
  let escapedChar1 s = s |> (pchar '\\' >>. anyOf @"\""/bfnrt")
  @"\\"  |> parseBy escapedChar1 |> should equal '\\'
  @"\""" |> parseBy escapedChar1 |> should equal '"'
  @"\n"  |> parseBy escapedChar1 |> should equal 'n' // 改行文字にしたい

  let convEsc = function
    | 'b' -> '\b'
    | 'f' -> '\f'
    | 'n' -> '\n'
    | 'r' -> '\r'
    | 't' -> '\t'
    | c -> c      // '\\', '"', '/' はそのまま使う

  let escapedChar2 s = s |> (pchar '\\' >>. anyOf @"\""/bfnrt" |>> convEsc)

  """エスケープ文字対応"""
  let jstring2 s =
    s |> (manyChars (nonEscapedChar <|> escapedChar2) // どちらかの繰り返し
          |> between (pchar '"') (pchar '"')
          .>> ws
          |>> JString)

  "\"abc\""       |> parseBy jstring2 |> should equal (JString "abc")
  "\"abc\\ndef\"" |> parseBy jstring2 |> should equal (JString "abc\ndef")

  "TODO 「選択されない選択肢」から"

"""TODO: https://tyrrrz.me/blog/parsing-with-fparsec"""
