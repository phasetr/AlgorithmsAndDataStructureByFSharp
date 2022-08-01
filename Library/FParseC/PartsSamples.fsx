#r "nuget: FsUnit"
open FsUnit
#r "nuget: FParsec"
open FParsec

@"Official Reference
https://www.quanttec.com/fparsec/reference/"

@"https://bleis-tift.hatenablog.com/entry/json-parser-using-fparsec"
let parseBy p str =
  match run (between ws eof p) str with
    | Success (res, _, _) -> res
    | Failure (msg, _, _) -> failwithf "parse error: %s" msg

module SymbolsSample =
  """<|>, or"""
  "a" |> parseBy (pchar 'a' <|> pchar 'b') |> should equal 'a'
  "b" |> parseBy (pchar 'a' <|> pchar 'b') |> should equal 'b'

  let parserA: Parser<string,unit> = spaces >>. pstring "a"
  let parserB: Parser<string,unit> = spaces >>. pstring "b"
  parseBy (parserA <|> parserB) " b" |> should equal "b"
  parseBy (spaces >>. (pstring "a" <|> pstring "b")) " b" |> should equal "b"

  """>>?"""
  let numberInBrackets s = s |> (pstring "[" >>? pint32 .>> pstring "]" .>> spaces)
  parseBy (many numberInBrackets .>> pstring "[c]") "[1] [2] [c]" |> should equal [1;2]

module AnyofSample =
  """
  noneOf の逆.
  引数で指定された seq<char> のうちの1文字をパースするパーサーを返す.
  """
  "a" |> parseBy (anyOf "abc") |> should equal 'a'
  "c" |> parseBy (anyOf "abc") |> should equal 'c'
  (fun () -> "z" |> parseBy (anyOf "abc") |> ignore) |> should throw typeof<System.Exception>

module AttemptSample =
  (fun () -> parseBy (attempt (pstring "a" >>. pstring "b")) "ac" |> ignore) |> should throw typeof<System.Exception>

  let ab: Parser<string*string,unit> = pstring "a" .>>. pstring "b"
  let ac: Parser<string*string,unit> = pstring "a" .>>. pstring "c"
  (fun () -> parseBy (ab <|> ac) "ac" |> ignore) |> should throw typeof<System.Exception>
  parseBy ((attempt ab) <|> ac) "ac" |> should equal ("a","c")

  let bInBrackets s = s |> (pstring "[" >>. pstring "b" .>> pstring "]")
  (fun () -> parseBy ((attempt (pstring "a" .>>. bInBrackets)) <|> ac) "a[B]" |> ignore) |> should throw typeof<System.Exception>
  (fun () -> parseBy ((attempt (pstring "a" .>>. bInBrackets)) <|> attempt ac) "a[B]" |> ignore) |> should throw typeof<System.Exception>
  (fun () -> parseBy (pstring "a" .>>.? bInBrackets <|> ac) "a[B]" |> ignore) |> should throw typeof<System.Exception>

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

  // 捨てるとは言ってもパースしないわけではないため後続のパーサーが失敗すると全体として失敗する.
  (fun () -> "ho" |> parseBy hi2 |> ignore) |> should throw typeof<System.Exception>

module FollowedBySample =
  let p1 s = s |> (followedBy    (satisfy ((<>) '0')) >>. pint32)
  let p2 s = s |> (notFollowedBy (pstring "0")        >>. pint32)
  parseBy p1 "123" |> should equal 123
  (fun () -> parseBy p1 "01" |> ignore) |> should throw typeof<System.Exception>
  parseBy p2 "123" |> should equal 123
  (fun () -> parseBy p2 "01" |> ignore) |> should throw typeof<System.Exception>

  (fun () -> parseBy (followedByL (satisfy ((<>) '0')) "positive int w/o leading 0" >>. pint32) "01" |> ignore) |> should throw typeof<System.Exception>
  (fun () -> parseBy (followedBy (satisfy ((<>) '0')) >>. pint32 <?> "positive int w/o leading 0") "01" |> ignore) |> should throw typeof<System.Exception>
  (fun () -> parseBy (notFollowedByL (pstring "0") "'0'" >>. pint32) "01" |> ignore) |> should throw typeof<System.Exception>
  (fun () -> parseBy (many1SatisfyL isLetter "identifier") "123" |> ignore) |> should throw typeof<System.Exception>

module ManySample =
  let number: Parser<int32,unit> = pint32 .>> spaces
  parseBy (many number) "1 2 3 4" |> should equal [1..4]

  let numberInBrackets: Parser<int32,unit> = pstring "[" >>. pint32 .>> pstring "]" .>> spaces
  parseBy (many numberInBrackets .>> pstring "(c)") "[1] [2] (c)" |> should equal [1;2]
  (fun () -> parseBy (many numberInBrackets >>. pstring "[c]") "[1] [2] [c]" |> ignore) |> should throw typeof<System.Exception>

module Many1Sample =
  parseBy (many (many1 digit .>> spaces)) "123 456" |> should equal [['1'..'3'];['4'..'6']]

module ManyCharsSample =
  "abc" |> parseBy (manyChars (noneOf "xyz")) |> should equal "abc"
  (fun () -> "axc" |> parseBy (manyChars (noneOf "xyz")) |> ignore) |> should throw typeof<System.Exception>

module Many1CharsSample =
  // https://bleis-tift.hatenablog.com/entry/json-parser-using-fparsec
  let digit1to9: Parser<'a,unit> = anyOf ['1'..'9']
  let integer = (many1Chars2 digit1to9 digit <|> pstring "0") |>> int
  parseBy integer "0"
  parseBy integer "1"
  parseBy integer "11"
  (fun () -> parseBy integer "a" |> ignore) |> should throw typeof<System.Exception>

module NoneofSample =
  """string は seq<char> でもあるので、 ['x'; 'y'; 'z'] の代わりに "xyz" と書いてもOK"""
  "a" |> parseBy (noneOf "xyz") |> should equal 'a'
  (fun () -> "y" |> parseBy (noneOf "xyz") |> ignore) |> should throw typeof<System.Exception>

module SepBySample =
  let sepList   : Parser<int32 list,unit> = between (pstring "[") (pstring "]") (sepBy    pint32 (pstring ";"))
  let sepEndList: Parser<int32 list,unit> = between (pstring "[") (pstring "]") (sepEndBy pint32 (pstring ";"))
  parseBy sepList "[]" |> should equal ([]:int32 list)
  parseBy sepList "[1;2;3]" |> should equal [1..3]
  (fun () -> parseBy sepList "[1;2;3;]" |> ignore) |> should throw typeof<System.Exception>

  parseBy sepEndList "[1;2;3]" |> should equal [1..3]
  parseBy sepEndList "[1;2;3;]" |> should equal [1..3]
