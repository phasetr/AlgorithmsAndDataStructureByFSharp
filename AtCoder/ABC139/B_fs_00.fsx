// https://atcoder.jp/contests/abc139/tasks/abc139_b
#r "nuget: FsUnit"
open FsUnit

let rec solve a b n numA =
    if b = 1 then 0
    elif numA >= b then n
    else
        let tmpNum =
            if n = 0 then 0
            elif n = 1 then a
            else a + (a-1) * (n-1)
        if tmpNum >= b then n
        else solve a b (n+1) tmpNum

let a,b = stdin.ReadLine().Split(' ') |> Array.map int |> (fun x -> x.[0],x[1])
solve a b 0 0 |> printfn "%d"

solve 4 10 0 0 |> should equal 3
solve 8 9 0 0 |> should equal 2
solve 8 8 0 0 |> should equal 1
