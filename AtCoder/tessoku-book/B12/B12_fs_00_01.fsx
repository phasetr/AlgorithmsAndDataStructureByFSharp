#r "nuget: FsUnit"
open FsUnit

(*
cf. https://www.wolframalpha.com/input?i=x%5E3%2Bx-1&lang=ja
let N = 2
*)
let solve N =
  let f x = x*x*x + x - (float N)
  let rec frec l r =
    if r-l<0.001 then l else let m = (l+r)/2.0 in if f m < 0.0 then frec m r else frec l m
  frec 0.0 (float N |> sqrt)
let N = stdin.ReadLine() |> int
solve N |> stdout.WriteLine

solve 2 // 1.000000
