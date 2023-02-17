#r "nuget: FsUnit"
open FsUnit

(*
let A,B = 25L,30L
let A,B = 998244353L,998244853L
*)
let solve A B =
  let gcd x y = let rec frec x y = if y=0L then x else frec y (x%y) in if x<=y then frec y x else frec x y
  A*B / (gcd A B)
let A,B = stdin.ReadLine().Split() |> Array.map int64 |> (fun x -> x.[0],x.[1])
solve A B |> stdout.WriteLine

solve 25L 30L |> should equal 150L
solve 998244353L 998244853L |> should equal 996492287418565109L
