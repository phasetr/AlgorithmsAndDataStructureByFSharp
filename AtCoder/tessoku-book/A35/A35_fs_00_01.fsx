#r "nuget: FsUnit"
open FsUnit

(*
let N,Aa = 4,[|20;10;30;40|]
*)
let solve N (Aa:int[]) =
  (Aa,[|(N-2)..(-1)..0|])
  ||> Array.fold (fun dp i ->
    let f = if i&&&1=0 then max else min
    [|0..i|] |> Array.iter (fun j -> dp.[j] <- f dp.[j] dp.[j+1])
    dp)
  |> Array.head

let N = stdin.ReadLine() |> int
let Aa = stdin.ReadLine().Split() |> Array.map int
solve N Aa |> stdout.WriteLine

solve 4 [|20;10;30;40|] |> should equal 30
