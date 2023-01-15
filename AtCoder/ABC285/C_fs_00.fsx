#r "nuget: FsUnit"
open FsUnit

(*
let S = "AB"
*)
let solve S =
  let cToInt (c:char) = (int64 c) - 64L
  S |> Seq.rev |> Seq.mapi (fun i c -> (pown 26L i) * (cToInt c)) |> Seq.sum

let S = stdin.ReadLine()
solve S |> stdout.WriteLine

solve "AB" |> should equal 28L
solve "C" |> should equal 3L
solve "BRUTMHYHIIZP" |> should equal 10000000000000000L
