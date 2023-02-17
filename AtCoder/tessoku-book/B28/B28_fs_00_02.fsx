#r "nuget: FsUnit"
open FsUnit

(*
let N = 6
let N = 8691200
*)
let solve N =
  let MOD = 1_000_000_007
  let (.+) a b = (a+b)%MOD
  let mutable n1,n2,ans = 1,1,0
  for _ in 3..N do ans <- n1.+n2; n2 <- n1; n1 <- ans
  ans
let N = stdin.ReadLine() |> int
solve N |> stdout.WriteLine

solve 6 |> should equal 8
solve 8691200 |> should equal 922041576
