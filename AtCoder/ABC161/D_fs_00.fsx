#r "nuget: FsUnit"
open FsUnit

let K = 15
let K = 13
let solve K =
  let q = System.Collections.Generic.Queue<int64>()
  [|1L..9L|] |> Array.iter q.Enqueue
  (0L, [|0..K-1|]) ||> Array.fold (fun acc _ ->
    let acc = q.Dequeue()
    let r = acc%10L
    [r-1L;r;r+1L] |> List.filter (fun i -> 0L<=i && i<=9L) |> List.map (fun a -> 10L*acc+a) |> List.iter q.Enqueue
    acc)

let K = stdin.ReadLine() |> int
solve K |> stdout.WriteLine

solve 15 |> should equal 23L
solve 1 |> should equal 1L
solve 13 |> should equal 21
solve 100000 |> should equal 3234566667L
