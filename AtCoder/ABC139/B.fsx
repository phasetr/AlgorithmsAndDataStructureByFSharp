// https://atcoder.jp/contests/abc139/tasks/abc139_b
let rec fb a b n numA =
    if b = 1 then 0
    elif numA >= b then n
    else
        let tmpNum =
          if n = 0 then 0
          elif n = 1 then a
          else a + (a-1) * (n-1)
        if tmpNum >= b then n
        else fb a b (n+1) tmpNum

//let input = [| [|4, 10|]; [| 8, 9 |]; [| 8, 8 |]; [| 2, 1|]; [| 20, 1 |] |]
//for [|a,b|] in input do fb a b 0 |> printfn "%d"

[<EntryPoint>]
let main argv =
    let input = stdin.ReadLine().Split(' ') |> Array.map int
    let a = input.[0]
    let b = input.[1]
    fb a b 0 0 |> printfn "%d"
    0
