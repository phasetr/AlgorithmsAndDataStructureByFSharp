// https://atcoder.jp/contests/abc068/tasks/abc068_b

let rec divNumBy2 num acc =
    if num = 0 then 0
    else if num = 1 && acc = 0 then 1
    else if num % 2 = 0 then divNumBy2 (num / 2) (acc + 1)
    else acc

let judge n =
    let helper (i, divNum) (accI, addDivNum) =
        if divNum <= addDivNum then (accI, addDivNum) else (i, divNum)

    [| for i in [ 0 .. n ] do
        yield (i, divNumBy2 i 0) |]
    |> Array.fold helper (0, 0)
    |> fst

//let input = [| 7; 32; 1; 100 |]
//for i in input do judge i |> printfn "%d"
// expected 4; 32; 1; 64

[<EntryPoint>]
let main argv =
    let n = stdin.ReadLine() |> int
    judge n |> printfn "%d"
    0
