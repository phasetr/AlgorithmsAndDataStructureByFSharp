#r "nuget: FsUnit"
open FsUnit

let N,Aa,Ba = 3,[|1L;2L;3L|],[|5L;2L;2L|]
let N,Aa,Ba = 5,[|3L;1L;4L;1L;5L|],[|2L;7L;1L;8L;2L|]
let solve N Aa Ba =
  let t = (Array.sum Ba) - (Array.sum Aa)
  let s1 = (0L,Aa,Ba) |||> Array.fold2 (fun acc a b -> if a<b then acc+((b-a+1L)/2L) else acc)
  let s2 = (0L,Aa,Ba) |||> Array.fold2 (fun acc a b -> if a<b then acc else acc+(a-b))
  if (max s1 s2)<=t then "Yes" else "No"

let N = stdin.ReadLine() |> int
let Aa = stdin.ReadLine().Split() |> Array.map int64
let Ba = stdin.ReadLine().Split() |> Array.map int64
solve N Aa Ba |> stdout.WriteLine

solve 3 [|1L;2L;3L|] [|5L;2L;2L|] |> should equal "Yes"
solve 5 [|3L;1L;4L;1L;5L|] [|2L;7L;1L;8L;2L|] |> should equal "No"
solve 5 [|2L;7L;1L;8L;2L|] [|3L;1L;4L;1L;5L|] |> should equal "No"
