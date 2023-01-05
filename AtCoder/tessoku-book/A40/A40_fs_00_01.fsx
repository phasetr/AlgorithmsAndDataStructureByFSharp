#r "nuget: FsUnit"
open FsUnit

(*
let N,Aa = 7,[|1;2;1;2;1;2;1|]
*)
let solve N Aa =
  let comb n = (n*(n-1L)*(n-2L)) / 6L
  Aa |> Array.groupBy id |> Array.choose (fun (_,Xa) ->
    Xa |> Array.length |> fun l -> if l<3 then None else l |> int64 |> Some)
  |> Array.sumBy comb

let N = stdin.ReadLine() |> int
let Aa = stdin.ReadLine().Split() |> Array.map int
solve N Aa |> stdout.WriteLine

solve 7 [|1;2;1;2;1;2;1|] |> should equal 5L
