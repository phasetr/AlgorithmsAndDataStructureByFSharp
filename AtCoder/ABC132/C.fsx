// https://atcoder.jp/contests/abc132/tasks/abc132_c
// TLE になったコード
let judge k ds =
    let arc = ds |> Array.filter (fun x -> x >= k)
    let abc = ds |> Array.filter (fun x -> x < k)
    arc.Length = abc.Length

let rec helper k max ds acc =
    if k > max then acc
    else if judge k ds then helper (k + 1) max ds (acc + 1)
    else helper (k + 1) max ds acc

let solve ds =
    let min = ds |> Array.min
    let max = ds |> Array.max
    helper min max ds 0

//let input = [| 6, [|9; 1; 4; 4; 6; 7|]; 8, [| 9; 1; 14; 5; 5; 4; 4; 14 |]; 14, [| 99592; 10342; 29105; 78532; 83018; 11639; 92015; 77204; 30914; 21912; 34519; 80835; 100000; 1 |] |]
//for _, ds in input do (solve ds |> printfn "%d")
// expected 2; 0; 42685
[<EntryPoint>]
let main argv =
    stdin.ReadLine() |> ignore
    stdin.ReadLine().Split()
    |> Array.map int
    |> solve
    |> printfn "%d"
    0
