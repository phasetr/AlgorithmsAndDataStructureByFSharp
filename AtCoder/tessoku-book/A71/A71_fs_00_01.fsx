#r "nuget: FsUnit"
open FsUnit

(*
let N,Aa,Ba = 3,[|10;20;30|],[|35;40;33|]
*)
let solve N Aa Ba =
  let Xa = Array.sort Aa
  let Ya = Array.sortDescending Ba
  [|0..N-1|] |> Array.sumBy (fun i -> Xa.[i]*Ya.[i])

let N = stdin.ReadLine() |> int
let Aa = stdin.ReadLine().Split() |> Array.map int
let Ba = stdin.ReadLine().Split() |> Array.map int
solve N Aa Ba |> stdout.WriteLine

solve 3 [|10;20;30|] [|35;40;33|] |> should equal 2090
