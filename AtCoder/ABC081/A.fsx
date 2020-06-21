// https://atcoder.jp/contests/abc081/tasks/abc081_a
let fa: string -> int = Seq.sumBy (fun x -> if x = '1' then 1 else 0)

//for i in [| "101"; "000" |] do fa i |> printfn "%d"

[<EntryPoint>]
let main argv =
    stdin.ReadLine() |> fa |> printfn "%d"
    0
