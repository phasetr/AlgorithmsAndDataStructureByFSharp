#r "nuget: FsUnit"
open FsUnit

let N,S = 3,"())"
let solve N (S:string) =
  let (b,m) = ((0,0), S) ||> Seq.fold (fun (b,m) c -> if c='(' then (b+1,m) else (b-1, min m (b-1)))
  let s0 = String.replicate (-m) "("
  let s1 = String.replicate (max 0 (b-m)) ")"
  s0+S+s1

let N = stdin.ReadLine() |> int
let S = stdin.ReadLine()
solve N S |> stdout.WriteLine

solve 3 "())" |> should equal "(())"
solve 6 ")))())" |> should equal "(((()))())"
solve 8 "))))((((" |> should equal "(((())))(((())))"
