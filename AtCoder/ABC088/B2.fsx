// https://atcoder.jp/contests/abc088/tasks/abc088_b
// https://atcoder.jp/contests/abc088/submissions/12247281
[<EntryPoint>]
let main _ =
    stdin.ReadLine() |> ignore
    stdin.ReadLine().Split()
    |> Array.map int
    |> Array.sortDescending
    |> Array.indexed
    |> Array.sumBy (fun (id, x) -> if id % 2 = 0 then x else -x)
    |> stdout.WriteLine
    0
