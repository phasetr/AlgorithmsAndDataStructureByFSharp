@"https://atcoder.jp/contests/abc046/tasks/abc046_b"
#r "nuget: FsUnit"
open FsUnit

@"N個のK色のペンキで塗る.
はじめにどれを選ぶか,
あとは一つ前に選んだ以外の色を選ぶ."
let solve N K =
    if N = 1I then K
    else
        Array.init (int (N-1I)) (fun _ -> K-1I)
        |> Array.fold (*) 1I
        |> fun x -> x * K

let N,K = stdin.ReadLine().Split() |> Array.map bigint.Parse |> (fun x -> x.[0], x.[1])
solve N K |> stdout.WriteLine

solve 2I 2I |> should equal 2I
solve 1I 10I |> should equal 10I
solve 10I 8I |> should equal 322828856I
