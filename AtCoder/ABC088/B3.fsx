// https://atcoder.jp/contests/abc088/tasks/abc088_b
// https://atcoder.jp/contests/abc088/submissions/5893568
stdin.ReadLine() |> ignore

stdin.ReadLine().Split(' ')
|> Array.map int
|> Array.sortDescending
|> Array.indexed
|> Array.partition (fun (id, x) -> id % 2 = 0)
|> fun (arrAlice, arrBob) ->
    (Array.sumBy snd arrAlice)
    - (Array.sumBy snd arrBob)
|> printfn "%d"
