@"https://atcoder.jp/contests/abc097/tasks/abc097_b"
#r "nuget: FsUnit"
open FsUnit

let solve X =
    let f n =
        if n = 1 then (seq [1])
        else Seq.initInfinite (fun x -> pown n (x+2)) |> Seq.takeWhile (fun x -> x <= X)
    [|1..X|]
    |> Array.map (fun n -> if n=1 then (seq {1}) else f n)
    |> Array.choose (fun xs -> if Seq.isEmpty xs then None else Some (Array.ofSeq xs))
    |> Array.concat
    |> Array.max

let X = stdin.ReadLine() |> int
solve X |> stdout.WriteLine

solve 10 |> should equal 9
solve 1 |> should equal 1
solve 999 |> should equal 961
