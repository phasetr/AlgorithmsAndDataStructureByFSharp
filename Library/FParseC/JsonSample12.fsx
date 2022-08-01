@"https://bleis-tift.hatenablog.com/entry/json-parser-using-fparsec"

#r "nuget: FsUnit"
open FsUnit
#r "nuget: FParsec"
open FParsec

"""
左再帰

JSONの文法はよく考えられていて何も考えずに実装しても問題ないようにできている.
JSONを勝手に拡張して問題を起こしてみよう.

次の入力をパースできるようにする.

[ 10 - 4 + 2, 20 ]
""" |> ignore

type NumExpr =
  | NEInteger of int           // 簡単のためにfloatは省略
  | NEAdd of NumExpr * NumExpr
  | NESub of NumExpr * NumExpr
type Json =
  | JNumExpr of NumExpr
  | JArray of Json list        // 簡単のためstringも

"""
はじめに: `[ 10 - 4 + 2, 20 ]`は次のようになるはず
JArray
  [ JNumExpr (NEAdd (NESub (NEInteger 10, NEInteger 4), NEInteger 2))
    JNumExpr (NEInteger 20) ]
""" |> ignore

let ws = spaces

let neinteger s = s |> (pint32 .>> ws |>> NEInteger)
let numExpr, numExprRef: Parser<NumExpr,unit> * Parser<NumExpr,unit> ref = createParserForwardedToRef ()
let neadd s = s |> ((numExpr .>> pchar '+' .>> ws) .>>. neinteger |>> NEAdd)
let nesub s = s |> ((numExpr .>> pchar '-' .>> ws) .>>. neinteger |>> NESub)
numExprRef.Value <- choice [attempt neadd; attempt nesub; neinteger]

let jnumExpr = numExpr |>> JNumExpr

let json, jsonRef: Parser<Json,unit> * Parser<Json,unit> ref = createParserForwardedToRef ()
let jarray =
  sepBy json (pchar ',' >>. ws)
  |> between (pchar '[' >>. ws) (pchar ']' >>. ws)
  |>> JArray
jsonRef.Value <- choice [jnumExpr; jarray]

let parseBy p str =
  match run (ws >>. p .>> eof) str with
  | Success (res, _, _) -> res
  | Failure (msg, _, _) -> failwithf "parse error: %s" msg

"""
Stack overflow
"[ 10 - 4 + 2, 20 ]" |> parseBy json
""" |> ignore

"""
問題箇所

let neadd =
  (numExpr .>> pchar '+' .>> ws) .>>. neinteger |>> NEAdd
let nesub =
  (numExpr .>> pchar '-' .>> ws) .>>. neinteger |>> NESub
numExprRef := choice [attempt neadd; attempt nesub; neinteger]
"""

"""修正
>>% 演算子は左項のパーサーが成功した場合に右項の値を返すパーサーを返す" |> ignore
"""
let () = "a" |> parseBy (pchar 'a' >>% [1; 2; 3]) |> should equal [1; 2; 3]

type Op = Add | Sub
let op s = s ((pchar '+' .>> ws >>% Add) <|> (pchar '-' .>> ws >>% Sub))
let numExpr =
  let f crnt (op, next) =
    match op with
      | Add -> NEAdd (crnt, next)
      | Sub -> NESub (crnt, next)
      | _ -> failwithf "not come here"
  neinteger .>>. many (op .>>. neinteger)
  |>> (fun (i, xs) -> List.fold (fun crnt (f, next) -> f crnt next) i xs)

"""chainl1を使うとすっきり書ける""" |> ignore
let op s = s |> (choice [ pchar '+' .>> ws >>% (fun a b -> NEAdd (a, b))
                          pchar '-' .>> ws >>% (fun a b -> NESub (a, b)) ])
let numExpr s = s |> (chainl1 neinteger op)
"[ 10 - 4 + 2, 20 ]" |> parseBy json
     // => JArray
     //      [JNumExpr (NEAdd (NESub (NEInteger 10,NEInteger 4),NEInteger 2));
     //       JNumExpr (NEInteger 20)]
