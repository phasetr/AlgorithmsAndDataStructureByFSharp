#r "nuget: FsUnit"
open FsUnit

let solve Aa =
  let mutable M,m = System.Int32.MinValue,System.Int32.MaxValue
  for a in Aa do M <- max M (a-m); m <- min m a done; M

let N = stdin.ReadLine() |> int
let Aa = [| for i in 1..N do (stdin.ReadLine() |> int) |]
solve Aa |> stdout.WriteLine

solve [|5;3;1;3;4;3|] |> should equal 3
solve [|4;3;2|] |> should equal -1
