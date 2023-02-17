#r "nuget: FsUnit"
open FsUnit

(*
let H,W = 1L,2L
let H,W = 5L,10L
let H,W = 869L,120L
*)
let solve H W =
  let MOD = 1_000_000_007L
  let (.*) a b = ((a%MOD)*(b%MOD))%MOD
  let p n r = let rec frec acc n r = if r=0L then acc else frec (n.*acc) (n-1L) (r-1L) in frec 1L n r
  let rec powm x n = if n=0 then 1L elif n&&&1=0 then powm (x.*x) (n/2) else x .* powm x (n-1)
  let inv a = powm a (MOD-2L |> int)
  let c n r = p n r .* inv (p r r)
  c (H+W-2L) (W-1L)
let H,W = stdin.ReadLine().Split() |> Array.map int64 |> (fun x -> x.[0],x.[1])
solve H W |> stdout.WriteLine

solve 1L 2L |> should equal 1L
solve 5L 10L |> should equal 715L
solve 869L 120L |> should equal 223713395L
