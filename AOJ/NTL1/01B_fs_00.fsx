#r "nuget: FsUnit"
open FsUnit

let solve M N =
  let rec modpow M N MOD =
    if N = 0 then 1
    else if N%2 = 0 then modpow (M*M % MOD) (N/2) MOD
    else (M * modpow M (N-1) MOD) % MOD
  modpow M N 1_000_000_007

let M,N = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
solve M N |> stdout.WriteLine

solve 2 3 |> should equal 8
solve 5 8 |> should equal 390625
