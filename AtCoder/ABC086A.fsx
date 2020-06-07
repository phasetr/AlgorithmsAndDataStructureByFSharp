// https://atcoder.jp/contests/ABC086/tasks/abc086_a
stdin.ReadLine().Split(' ')
|> Array.map int
|> Array.reduce (*)
|> fun x -> if x % 2 = 0 then printfn "Even" else printfn "Odd"
