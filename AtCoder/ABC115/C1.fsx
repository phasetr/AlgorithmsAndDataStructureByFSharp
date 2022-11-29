@"https://atcoder.jp/contests/abc115/tasks/abc115_c"
#r "nuget: FsUnit"
open FsUnit

let solve N K hs =
  let ks = Array.sort hs
  [|0..(N-K)|]
  |> Array.map (fun i -> ks.[i+K-1] - ks.[i])
  |> Array.min
let N, K = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
let hs = Array.init N (fun _ -> stdin.ReadLine() |> int)
solve N K hs |> stdout.WriteLine

solve 5 3 [|10;15;11;14;12|] |> should equal 2
solve 5 3 [|5;7;5;7;7|] |> should equal 0
