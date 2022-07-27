@"https://bleis-tift.hatenablog.com/entry/json-parser-using-fparsec"

#r "nuget: FsUnit"
open FsUnit
#r "nuget: FParsec"
open FParsec

type Json =
  | JNumber of float    // F#のfloatは64bit
  | JArray of Json list // F#では配列よりもlistの方が扱いやすい

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
