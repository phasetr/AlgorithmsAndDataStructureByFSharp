(*
問題文
あなたは、冷蔵庫と電子レンジを買うために、とある家電量販店に来ました。
この家電量販店ではA 種類の冷蔵庫と B 種類の電子レンジが販売されています。
i 番目( 1≤i≤A )の冷蔵庫の値段は ai円であり、
j 番目( 1≤j≤B )の電子レンジの値段は bj円です。
また、あなたは M 種類の割引券を所持しており、
i 番目 ( 1≤i≤M )の割引券では、
xi番目の冷蔵庫 と yi番目の電子レンジを同時に買うと、
支払総額が ci円安くなります。
ただし、複数の割引券を同時に使うことはできません。

さて、あなたは冷蔵庫と電子レンジをちょうど 1 台ずつ買おうと思っています。
かかる金額の最小値を求めてください。

制約
入力は全て整数
1≤A≤10^5
1≤B≤10^5
1≤M≤10^5
1≤ai, bi,ci≤10^5
1≤xi ≤A
1≤yi ≤B
ci≤a_{xi}+b_{yi}
*)
#r "nuget: FsUnit"
open System
open System.IO
open FsUnit

let discountValue (As: int[]) (Bs: int[]) (d: int[]) =
    As.[d.[0]-1] + Bs.[d.[1]-1] - d.[2]

let solve A B M As Bs Ds =
    let simple = Array.min As + Array.min Bs
    let discounted = Ds |> Array.map (discountValue As Bs) |> Array.min
    min simple discounted

let A, B, M = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1], x.[2])
let As = stdin.ReadLine().Split() |> Array.map int
let Bs = stdin.ReadLine().Split() |> Array.map int
let Ds = [| for i in 1..M do (stdin.ReadLine().Split() |> Array.map int) |]
solve A B M As Bs Ds |> printfn "%A"

solve 2 3 1 [|3; 3|] [|3; 3; 3|] [|[|1; 2; 1|]|]
|> should equal 5
solve 1 1 2 [|10|] [|10|] [|[|1; 1; 5|]; [|1; 1; 10|]|]
|> should equal 10
solve 2 2 1 [|3; 5|] [|3; 5|] [|[|2;2;2|]|]
|> should equal 6
