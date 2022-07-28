@"https://bleis-tift.hatenablog.com/entry/json-parser-using-fparsec"

#r "nuget: FsUnit"
open FsUnit
#r "nuget: FParsec"
open FParsec

type Json =
  | JNumber of float    // F#のfloatは64bit
  | JArray of Json list // F#では配列よりもlistの方が扱いやすい

let ws = spaces
let jnumber s = s |> (pfloat .>> ws |>> JNumber)
let jarray s =
  s |> (sepBy jnumber (pchar ',' >>. ws)
        |> between (pchar '[' >>. ws) (pchar ']' >>. ws)
        |>> JArray)

let parseBy p str =
  match run (between ws eof p) str with
    | Success (res, _, _) -> res
    | Failure (msg, _, _) -> failwithf "parse error: %s" msg

let () =
  "[ 1, 2, 3 ]" |> parseBy jarray |> should equal (JArray [JNumber 1.0; JNumber 2.0; JNumber 3.0])
  (fun () -> "[1, 2, 3]]]]" |> parseBy jarray |> ignore) |> should throw typeof<System.Exception>

let () =
  /// 既存のテスト
  "1.5" |> parseBy pfloat |> should equal 1.5
  "1.5" |> parseBy jnumber |> should equal (JNumber 1.5)
  "1,2,3" |> parseBy (sepBy jnumber (pchar ',')) |> should equal [JNumber 1.0; JNumber 2.0; JNumber 3.0]
  "[1,2,3]" |> parseBy jarray |> should equal (JArray [JNumber 1.0; JNumber 2.0; JNumber 3.0])
