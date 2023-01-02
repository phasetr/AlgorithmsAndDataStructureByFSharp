#r "nuget: FsUnit"
open FsUnit

(*
let N,R = 4L,2L
let N,R = 77777,44444L
*)
let solve N R =
  let MOD = 1_000_000_007L
  let (.+) a b = ((a%MOD)+(b%MOD))%MOD
  let (.*) a b = ((a%MOD)*(b%MOD))%MOD
  let p n r = let rec frec acc n r = if r=0L then acc else frec (n.*acc) (n-1L) (r-1L) in frec 1L n r
  let rec powm x n = if n=0 then 1L elif n&&&1=0 then powm (x.*x) (n/2) else x .* powm x (n-1)
  let inv a = powm a (MOD-2L |> int)
  let c n r = p n r .* inv (p r r)
  c N R

let N,R = stdin.ReadLine().Split() |> Array.map int64 |> (fun x -> x.[0],x.[1])
solve N R |> stdout.WriteLine

solve 4L 2L |> should equal 6L
solve 77777L 44444L |> should equal 409085577L
