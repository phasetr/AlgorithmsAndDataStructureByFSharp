@"https://bleis-tift.hatenablog.com/entry/json-parser-using-fparsec"

#r "nuget: FsUnit"
open FsUnit
#r "nuget: FParsec"
open FParsec
#load "JsonSample01.fsx"
open JsonSample01

type Json =
  | JNumber of float    // F#のfloatは64bit
  | JArray of Json list // F#では配列よりもlistの方が扱いやすい

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

let () =
  "[ 1, 2, 3 ]" |> parseBy jarray |> should equal (JArray [JNumber 1.0; JNumber 2.0; JNumber 3.0])
  """嫌な例: 前方一致のために`]]]`が無視されて通ってしまう""" |> ignore
  "[1, 2, 3]]]]" |> parseBy jarray |> should equal (JArray [JNumber 1.0; JNumber 2.0; JNumber 3.0])

let () =
  /// 既存のテスト
  "1.5" |> parseBy pfloat |> should equal 1.5
  "1.5" |> parseBy jnumber |> should equal (JNumber 1.5)
  "1,2,3" |> parseBy (sepBy jnumber (pchar ',')) |> should equal [JNumber 1.0; JNumber 2.0; JNumber 3.0]
  "[1,2,3]" |> parseBy jarray |> should equal (JArray [JNumber 1.0; JNumber 2.0; JNumber 3.0])
