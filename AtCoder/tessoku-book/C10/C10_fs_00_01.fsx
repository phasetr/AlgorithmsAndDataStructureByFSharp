#r "nuget: FsUnit"
open FsUnit

(*
let W = 1L
let W = 2L
let W = 100L
*)
let solve W =
  let MOD = 1_000_000_007L
  let (.*) a b = ((a%MOD)*(b%MOD))%MOD
  let rec powmod x n = if n=0L then 1L else if n%2L=0L then powmod (x.*x) (n/2L) else x .* (powmod x (n-1L))
  12L .* (powmod 7L (W-1L))
let W = stdin.ReadLine() |> int64
solve W |> stdout.WriteLine

solve 1L |> should equal 12L
solve 2L |> should equal 84L
solve 100L |> should equal 908287499L
