#r "nuget: FsUnit"
open FsUnit

let N,Aa = 3,[|2L;2L;4L|]
let solve N Aa =
  let x0 = ((0L,0),Aa) ||> Array.fold (fun (acc,i) a -> ((if i%2=0 then acc+a else acc-a), i+1)) |> fst
  (x0, Aa |> Array.take (N-1)) ||> Array.scan (fun acc x -> 2L*x - acc)

let N = stdin.ReadLine() |> int
let Aa = stdin.ReadLine().Split() |> Array.map int64
solve N Aa |> Array.map string |> String.concat " " |> stdout.WriteLine

solve 3 [|2L;2L;4L|] |> should equal [|4L;0L;4L|]
solve 5 [|3L;8L;7L;5L;5L|] |> should equal [|2L;4L;12L;2L;8L|]
solve 3 [|1000000000L;1000000000L;0L|] |> should equal [|0L;2000000000L;0L|]
