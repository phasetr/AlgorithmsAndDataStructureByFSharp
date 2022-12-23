#r "nuget: FsUnit"
open FsUnit

(*
let N,K = 5L,3L
let N,K = 2000L,3L
*)
let solve N K =
  let MOD = 1_000_000_007L
  let p n r = let rec frec acc n r = if r=0L then acc else frec ((n*acc)%MOD) (n-1L) (r-1L) in frec 1L n r
  let rec powm x n = if n=0L then 1L else if n%2L=0L then powm (x*x % MOD) (n/2L) else (x * (powm x (n-1L)) % MOD)
  let inv a = powm a (MOD-2L)
  let c n r = ((p n r) * (inv (p r r))) % MOD
  [|1L..K|] |> Array.map (fun i -> c (N-K+1L) i * c (K-1L) (i-1L) % MOD)
let N,K = stdin.ReadLine().Split() |> Array.map int64 |> (fun x -> x.[0],x.[1])
solve N K |> Array.iter stdout.WriteLine

solve 5L 3L |> should equal [|3L;6L;1L|]
solve 2000L 3L |> should equal [|1998L;3990006L;327341989L|]
