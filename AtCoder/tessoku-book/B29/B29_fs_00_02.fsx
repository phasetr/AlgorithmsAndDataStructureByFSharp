#r "nuget: FsUnit"
open FsUnit

(*
let A,B = 6L,3L
let A,B = 123456789L,123456789012345678L
*)
let solve A B =
  let MOD = 1_000_000_007L
  let (.*) a b = ((a%MOD)*(b%MOD))%MOD
  let rec powmod x n = if n=0L then 1L else if n%2L=0L then powmod (x.*x) (n/2L) else x .* (powmod x (n-1L))
  powmod A B
let A,B = stdin.ReadLine().Split() |> Array.map int64 |> (fun x -> x.[0],x.[1])
solve A B |> stdout.WriteLine

solve 6L 3L |> should equal 216L
solve 123456789L 123456789012345678L |> should equal 3599437L
