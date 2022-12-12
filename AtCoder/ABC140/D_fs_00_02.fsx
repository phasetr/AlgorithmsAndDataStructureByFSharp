#r "nuget: FsUnit"
open FsUnit

(*
let N,K,S = 6,1,"LRLRRL"
*)
let solve N K S =
  let s = S |> Seq.pairwise |> Seq.sumBy (fun (a,b) -> if a=b then 1 else 0)
  min (s+2*K) (N-1)

let N,K = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let S = stdin.ReadLine()
solve N K S |> stdout.WriteLine

solve 6 1 "LRLRRL" |> should equal 3
solve 13 3 "LRRLRLRRLRLLR" |> should equal 9
solve 10 1 "LLLLLRRRRR" |> should equal 9
solve 9 2 "RRRLRLRLL" |> should equal 7

"LRLR" |> Seq.pairwise |> should equal (seq [('L', 'R'); ('R', 'L'); ('L', 'R')])
