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

let nonEscapedChar s = s |> noneOf ['\\'; '"']

let convEsc = function
  | 'b' -> '\b'
  | 'f' -> '\f'
  | 'n' -> '\n'
  | 'r' -> '\r'
  | 't' -> '\t'
  | c -> c      // '\\', '"', '/' はそのまま使う

let escapedChar s = s |> (pchar '\\' >>. anyOf @"\""/bfnrt" |>> convEsc)

@"\n"  |> parseBy escapedChar |> should equal '\010' // 改行文字化

/// エスケープ文字対応
let jstring s =
  s |> (manyChars (nonEscapedChar <|> escapedChar) // どちらかの繰り返し
        |> between (pchar '"') (pchar '"')
        .>> ws
        |>> JString)

"\"abc\""       |> parseBy jstring |> should equal (JString "abc")
"\"abc\\ndef\"" |> parseBy jstring |> should equal (JString "abc\ndef")


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

@"\\"  |> parseBy escapedChar |> should equal '\\'
@"\""" |> parseBy escapedChar |> should equal '"'
