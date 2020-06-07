// https://atcoder.jp/contests/abc081/tasks/abc081_a
let aTest = "101"

let fa =
    Seq.sumBy (fun x -> if x = '1' then 1 else 0)

aTest |> fa |> printfn "%d"

let main = stdin.ReadLine() |> fa |> printfn "%d"
