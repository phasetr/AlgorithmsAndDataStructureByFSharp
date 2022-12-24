#r "nuget: FsUnit"
open FsUnit

(*
let N = -9
let N = 123456789
let N = 0
*)
let solve N =
  let rec frec acc n =
    if n=0 then acc
    else let k = abs (n%2) in frec (k::acc) ((k-n)/2)
  if N=0 then [0] else frec [] N
  |> List.map string |> String.concat ""

let N = stdin.ReadLine() |> int
solve N |> stdout.WriteLine

solve (-9) |> should equal "1011"
solve 123456789 |> should equal "11000101011001101110100010101"
solve 0 |> should equal "0"
