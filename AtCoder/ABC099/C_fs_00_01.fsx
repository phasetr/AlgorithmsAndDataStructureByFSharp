#r "nuget: FsUnit"
open FsUnit

(*
let N = 127
let N = 3
let N = 44852
*)
let solve N =
  let rec frec k cc t = if t>0 then frec k (cc+t%k) (t/k) else cc
  (N,[|0..N|]) ||> Array.fold (fun res i ->
    let cc6 = frec 6 0 i
    let cc9 = frec 9 cc6 (N-i)
    if res <= cc9 then res else cc9)

let N = stdin.ReadLine() |> int
solve N |> stdout.WriteLine

solve 127 |> should equal 4
solve 3 |> should equal 3
solve 44852 |> should equal 16
