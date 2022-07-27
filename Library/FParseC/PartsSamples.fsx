#r "nuget: FsUnit"
open FsUnit
#r "nuget: FParsec"
open FParsec

@"https://bleis-tift.hatenablog.com/entry/json-parser-using-fparsec"
let parseBy p str =
  match run (between ws eof p) str with
    | Success (res, _, _) -> res
    | Failure (msg, _, _) -> failwithf "parse error: %s" msg

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

"""
TODO
many1Chars2
"""
