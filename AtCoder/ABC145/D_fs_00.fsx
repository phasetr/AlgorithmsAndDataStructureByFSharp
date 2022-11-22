#r "nuget: FsUnit"
open FsUnit

let X,Y = 3L,3L
let solve X Y =
  let MOD = 1_000_000_007L
  if (X+Y)%3L=0L then
    let rec powmod m x n = if n=0L then 1L else if n%2L=0L then powmod m (x*x % m) (n/2L) else (x * (powmod m x (n-1L)) % m)
    let permmod m n r =
      let rec frec acc n r = if r=0L then acc else frec ((n*acc)%m) (n-1L) (r-1L)
      frec 1L n r
    let invmod m a = powmod m a (m-2L)
    let combmod m n r = ((permmod m n r) * (invmod m (permmod m r r))) % m
    let n,m = (2L*Y-X)/3L, (2L*X-Y)/3L
    if n<0L || m<0L then 0L else combmod MOD (n+m) n
  else 0L

let X,Y = stdin.ReadLine().Split() |> Array.map int64 |> (fun x -> x.[0],x.[1])
solve X Y |> stdout.WriteLine

solve 3L 3L |> should equal 2L
solve 2L 2L |> should equal 0L
solve 999999L 999999L |> should equal 151840682L
