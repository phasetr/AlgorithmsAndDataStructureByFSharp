#r "nuget: FsUnit"
open FsUnit

let N,K,Aa = 2,2,[|2;1|]
let N,K,Aa = 10,998244353I,[|10;9;8;7;5;6;3;4;2;1|]
let solve N K Aa =
  let MOD = 1_000_000_007I
  let rec f acc = function
    | [||] -> acc
    | Aa ->
      let x = Array.head Aa
      let Xa = Array.tail Aa
      f (acc + Array.length (Array.filter (fun y -> y<x) Xa)) Xa
  let orig = f 0 Aa |> bigint
  let btw = Array.sum (Array.map (fun a -> Array.length (Array.filter (fun x -> x<a) Aa)) Aa) |> bigint
  (orig*K + btw*((K*(K-1I))/2I)) % MOD

let N,K = stdin.ReadLine().Split() |> (fun x -> int x.[0], bigint.Parse x.[1])
let Aa = stdin.ReadLine().Split() |> Array.map int
solve N K Aa |> stdout.WriteLine

solve 2 2I [|2;1|] |> should equal 3I
solve 3 5I [|1;1;1|] |> should equal 0I
solve 10 998244353I [|10;9;8;7;5;6;3;4;2;1|] |> should equal 185297239I
