#r "nuget: FsUnit"
open FsUnit

(*
let A,B = 33,88
let A,B = 88,33
let A,B = 777,123
let A,B = 123,777
*)
let solve A B =
  let gcd a b =
    let rec frec x y = if x=0 then y else frec (y%x) x
    if a<b then frec a b else frec b a
  gcd A B

let A,B = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
solve A B |> stdout.WriteLine

solve 33 88 |> should equal 11
solve 88 33 |> should equal 11
solve 123 777 |> should equal 3
solve 777 123 |> should equal 3
