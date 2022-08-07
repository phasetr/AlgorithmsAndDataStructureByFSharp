#r "nuget: FsUnit"
open FsUnit

let Aa = [|5;3;1;3;4;3|]
let Aa = [|4;3;2|]
let solve Aa =
  let As = Array.toSeq Aa
  Seq.map2 (-) (Seq.tail As) (Seq.scan min System.Int32.MaxValue As |> Seq.tail) |> Seq.max

let N = stdin.ReadLine() |> int
let Aa = [| for i in 1..N do (stdin.ReadLine() |> int) |]
solve Aa |> stdout.WriteLine

solve [|5;3;1;3;4;3|] |> should equal 3
solve [|4;3;2|] |> should equal -1
