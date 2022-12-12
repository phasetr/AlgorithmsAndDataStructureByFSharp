#r "nuget: FsUnit"
open FsUnit

(*
let N,K,S = 6,1,"LRLRRL"
*)
let solve N K S =
  let s = (S, Seq.tail S) ||> Seq.map2 (=) |> Seq.filter id |> Seq.length
  min (s+2*K) (N-1)

let N,K = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let S = stdin.ReadLine()
solve N K S |> stdout.WriteLine

solve 6 1 "LRLRRL" |> should equal 3
solve 13 3 "LRRLRLRRLRLLR" |> should equal 9
solve 10 1 "LLLLLRRRRR" |> should equal 9
solve 9 2 "RRRLRLRLL" |> should equal 7

let sCount S = (S, Seq.tail S) ||> Seq.map2 (=) |> Seq.filter id |> Seq.length
"LRLRRL" |> sCount
"LRRLRLRRLRLLR" |> sCount
"LLLLLRRRRR" |> sCount
"RRRLRLRLL" |> sCount


let S = "LRLR"
(S, Seq.tail S) ||> Seq.zip |> should equal (seq [('L', 'R'); ('R', 'L'); ('L', 'R')])
(S, Seq.tail S) ||> Seq.map2 (=) |> Seq.filter id |> Seq.length
