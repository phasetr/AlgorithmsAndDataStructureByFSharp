#r "nuget: FsUnit"
open FsUnit

(*
let N ="1101"
let N = "1"
let N = "100101"
let N = "10000000"
*)
let solve (N:string) =
  N |> Seq.rev
  |> Seq.fold (fun (i,acc) n -> (i+1,acc + (int n-48)*pown 2 i)) (0,0)
  |> snd
let N = stdin.ReadLine()
solve N |> stdout.WriteLine

solve "1101" |> should equal 13
solve "1" |> should equal 1
solve "100101" |> should equal 37
solve "10000000" |> should equal 128
