#r "nuget: FsUnit"
open FsUnit

(*
let N = -9
let N = 123456789
let N = 0
*)
let solve N =
  if N=0 then [|0|]
  else N |> Array.unfold (fun k -> if k=0 then None else let m = abs(k%(-2)) in Some (m, (m-k)/2)) |> Array.rev
  |> Array.map string |> String.concat ""

let N = stdin.ReadLine() |> int
solve N |> stdout.WriteLine

solve (-9) |> should equal "1011"
solve 123456789 |> should equal "11000101011001101110100010101"
solve 0 |> should equal "0"
