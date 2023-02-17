#r "nuget: FsUnit"
open FsUnit

(*
let A,B = 6L,3L
let A,B = 123456789L,123456789012345678L
*)
let solve A B =
  let MOD = 1_000_000_007L
  let (.*) a b = (a*b)%MOD
  let mutable a,b,r = A,B,1L
  while 0L<b do
    if b%2L=1L then r <- r.*a
    a <- a.*a; b <- b/2L
  r
let A,B = stdin.ReadLine().Split() |> Array.map int64 |> (fun x -> x.[0],x.[1])
solve A B |> stdout.WriteLine

solve 6L 3L |> should equal 216L
solve 123456789L 123456789012345678L |> should equal 3599437L
