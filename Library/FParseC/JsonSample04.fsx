@"https://bleis-tift.hatenablog.com/entry/json-parser-using-fparsec"

#r "nuget: FsUnit"
open FsUnit
#r "nuget: FParsec"
open FParsec

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

let parseBy p str =
  match run (between ws eof p) str with
    | Success (res, _, _) -> res
    | Failure (msg, _, _) -> failwithf "parse error: %s" msg

"""エスケープ非対応"""
let jstring s =
  s |> (manyChars (noneOf ['"'])
        |> between (pchar '"') (pchar '"')
        .>> ws
        |>> JString)

let nonEscapedChar s = s |> noneOf ['\\'; '"']

"""
エスケープされた文字を考える: ただし`\uxxxx`形式は除く.
エスケープされた文字は「開始文字()から始まりエスケープシーケンスの種類を表す文字が続く」.
"""
let escapedChar s = s |> (pchar '\\' >>. anyOf @"\""/bfnrt")
@"\\"  |> parseBy escapedChar |> should equal '\\'
@"\""" |> parseBy escapedChar |> should equal '"'
@"\n"  |> parseBy escapedChar |> should equal 'n' // 改行文字にしたい


/// 既存のテスト
"1.5" |> parseBy pfloat |> should equal 1.5
"1.5" |> parseBy jnumber |> should equal (JNumber 1.5)
"1,2,3" |> parseBy (sepBy jnumber (pchar ',')) |> should equal [JNumber 1.0; JNumber 2.0; JNumber 3.0]
"[1,2,3]" |> parseBy jarray |> should equal (JArray [JNumber 1.0; JNumber 2.0; JNumber 3.0])
"[ 1, 2, 3 ]" |> parseBy jarray |> should equal (JArray [JNumber 1.0; JNumber 2.0; JNumber 3.0])

/// エラーになってほしい
"""
"[1, 2, 3]]]]" |> parseBy jarray |> should equal (JArray [JNumber 1.0; JNumber 2.0; JNumber 3.0])
"""
