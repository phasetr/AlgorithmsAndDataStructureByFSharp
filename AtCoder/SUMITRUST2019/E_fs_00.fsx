#r "nuget: FsUnit"
open FsUnit

(*
let N,Aa = 6,[|0L;1L;2L;3L;4L;5L|]
let N,Aa = 3,[|0L;0L;0L|]
let N,Aa = 54,[|0L;0L;1L;0L;1L;2L;1L;2L;3L;2L;3L;3L;4L;4L;5L;4L;6L;5L;7L;8L;5L;6L;6L;7L;7L;8L;8L;9L;9L;10L;10L;11L;9L;12L;10L;13L;14L;11L;11L;12L;12L;13L;13L;14L;14L;15L;15L;15L;16L;16L;16L;17L;17L;17L|]
let N,Aa = 6,[|0L;1L;0L;0L;1L;2L|]
*)
let solve N Aa =
  let MOD = 1_000_000_007L
  let (.*) a b = (a*b)%MOD
  ((1L,(0L,0L,0L)), Aa)
  ||> Array.fold (fun (t,(x,y,z)) ai ->
    let ti = [|x;y;z|] |> Array.sumBy (fun w -> if w=ai then 1L else 0L)
    let xyz = if ai=x then (x+1L,y,z) elif ai=y then (x,y+1L,z) else (x,y,z+1L)
    (t.*ti, xyz))
  |> fst

let N = stdin.ReadLine() |> int
let Aa = stdin.ReadLine().Split() |> Array.map int64
solve N Aa |> stdout.WriteLine

solve 6 [|0L;1L;2L;3L;4L;5L|] |> should equal 3L
solve 3 [|0L;0L;0L|] |> should equal 6L
solve 54 [|0L;0L;1L;0L;1L;2L;1L;2L;3L;2L;3L;3L;4L;4L;5L;4L;6L;5L;7L;8L;5L;6L;6L;7L;7L;8L;8L;9L;9L;10L;10L;11L;9L;12L;10L;13L;14L;11L;11L;12L;12L;13L;13L;14L;14L;15L;15L;15L;16L;16L;16L;17L;17L;17L|] |> should equal 115295190L
solve 6 [|0L;1L;0L;0L;1L;2L|] |> should equal 24L
