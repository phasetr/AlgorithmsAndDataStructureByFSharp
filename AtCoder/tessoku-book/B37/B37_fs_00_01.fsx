#r "nuget: FsUnit"
open FsUnit

(*
let N = 4L
let N = 288L
*)
let solve N =
  let quotRem (x:int64) y = (x/y,x%y)
  let s n = n*(n+1L)/2L
  let s9 = s 9L
  let rec f a d p =
    if p=0L then a
    else let (q,r) = quotRem p 10L in f (a+r*(1L+N%d)+d*(s (r-1L) + q*s9)) (10L*d) q
  f 0L 1L N

let N = stdin.ReadLine() |> int64
solve N |> stdout.WriteLine

solve 4L |> should equal 10L
solve 288L |> should equal 2826L
