#r "nuget: FsUnit"
open FsUnit

(*
let A,B = 5L,23
let A,B = 97L,998244353
*)
let solve A B =
  let MOD = 1_000_000_007L
  let (.*) a b = (a*b)%MOD
  let rec pow x n = if n=0 then 1L elif n&&&1=0 then pow (x.*x) (n/2) else x .* pow x (n-1)
  pow A B

let A,B = stdin.ReadLine().Split() |> (fun x -> int64 x.[0], int x.[1])
solve A B |> stdout.WriteLine

solve 5L 23 |> should equal 871631629L
solve 97L 998244353 |> should equal 934801994L
