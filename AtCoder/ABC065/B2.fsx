@"https://atcoder.jp/contests/abc065/submissions/13487268
2 ≦ N ≦ 10^5
1 ≦ a_i ≦ N"
#r "nuget: FsUnit"
open FsUnit

let solve N (As: array<int>) =
    [|
        let mutable tmp = 1
        yield tmp
        for i in 0..(N-1) do
            tmp <- As.[tmp-1]
            yield tmp
    |]
    |> Array.tryFindIndex (fun i -> i = 2)
    |> fun x -> if Option.isSome x then Option.get x else -1

let N = stdin.ReadLine() |> int
let As = [| for i in 1..N do (stdin.ReadLine() |> int) |]
solve N As |> stdout.WriteLine

solve 3 [|3;1;2|] |> should equal 2
solve 4 [|3;4;1;2|] |> should equal -1
solve 5 [|3;3;4;2;4|] |> should equal 3
