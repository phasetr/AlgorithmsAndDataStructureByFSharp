#r "nuget: FsUnit"
open FsUnit

let solve Xa =
  let isPrime = function
    | 1 -> false
    | 2 -> true
    | n when n%2=0 -> false
    | n ->
      let rec frec x =
        if n<x*x then true
        else if n%x=0 then false
        else frec (x+2)
      frec 3
  Xa |> Array.filter isPrime |> Array.length

let N = stdin.ReadLine() |> int
let Aa = [| for i in 1..N do (stdin.ReadLine() |> int) |]
solve Aa |> stdout.WriteLine

solve [|2;3;4;5;6;7|] |> should equal 4
