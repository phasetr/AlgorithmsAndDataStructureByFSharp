#r "nuget: FsUnit"
open FsUnit

let N,A,B = 4L,1L,3L
let solve N A B =
  let MOD = 1_000_000_007L
  let rec powmod m x n = if n=0L then 1L else if n%2L=0L then powmod m (x*x % m) (n/2L) else (x * (powmod m x (n-1L)) % m)
  let permmod m n r =
    let rec frec acc n r = if r=0L then acc else frec ((n*acc)%m) (n-1L) (r-1L)
    frec 1L n r
  let invmod m a = powmod m a (m-2L)
  let combmod m n r = ((permmod m n r)*(invmod m (permmod m r r)))%m
  let r = (powmod MOD 2L N) - 1L - (combmod MOD N A) - (combmod MOD N B)
  (r+2L*MOD)%MOD

let N,A,B = stdin.ReadLine().Split() |> Array.map int64 |> (fun x -> x.[0],x.[1],x.[2])
solve N A B |> stdout.WriteLine

solve 4L 1L 3L |> should equal 7L
solve 1000000000L 141421L 173205L |> should equal 34076506L
