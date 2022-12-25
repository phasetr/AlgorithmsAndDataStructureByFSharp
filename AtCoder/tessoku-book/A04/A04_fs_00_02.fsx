#r "nuget: FsUnit"
open FsUnit

(*
let N = 13
let N = 37
let N = 1000
*)
let solve N =
  if N=0 then [|0|] else N |> Array.unfold (fun n -> if n=0 then None else Some (n%2,n/2))
  |> Array.rev
  |> Array.map string |> String.concat "" |> fun s -> s.PadLeft(10,'0')

let N = stdin.ReadLine() |> int
solve N |> stdout.WriteLine

solve 0 |> should equal "0000000000"
solve 13 |> should equal "0000001101"
solve 37 |> should equal "0000100101"
solve 1000 |> should equal "1111101000"
