#r "nuget: FsUnit"
open FsUnit

let N,Aa = 3,[|2L;2L;4L|]
let solve N Aa =
  let s = Aa |> Array.sum
  let x0 = s - ((0L,[|1..2..N-1|]) ||> Array.fold (fun acc i -> acc + (Array.item i Aa)*2L))
  ([x0],[|1..N-1|]) ||> Array.fold (fun acc i -> (2L*Aa.[i-1] - acc.[0])::acc) |> List.rev

let N = stdin.ReadLine() |> int
let Aa = stdin.ReadLine().Split() |> Array.map int64
solve N Aa |> Seq.map string |> String.concat " " |> stdout.WriteLine

solve 3 [|2L;2L;4L|] |> should equal [4L;0L;4L]
solve 5 [|3L;8L;7L;5L;5L|] |> should equal [2L;4L;12L;2L;8L]
solve 3 [|1000000000L;1000000000L;0L|] |> should equal [0L;2000000000L;0L]
