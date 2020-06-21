// https://atcoder.jp/contests/abc170/tasks/abc170_c
let fc x n p =
    if n = 0 then x
    else
        let s = Set.ofList [for x in [1..100] do yield x]
        let pSet = Set.ofArray p
        let diff = s - pSet
        let sorted = diff |> Set.map (fun a -> a, abs (a-x)) |> List.ofSeq |> List.sortBy (fun (_, diff) -> diff)
        let min = sorted.[0] |> snd
        sorted |> List.filter (fun (_, b) -> b = min) |> List.minBy (fun (num, _) -> num) |> fst

let input = [| (6, 5, [| 4; 7; 10; 6; 5 |]); (10, 5, [| 4; 7 ; 10; 6; 5 |]); (100, 0, [||]) |]
for (x,n,p) in input do fc x n p |> printfn "%A"

[<EntryPoint>]
let main argv =
    let a = stdin.ReadLine().Split(' ') |> Array.map int
    let x = a.[0]
    let n = a.[1]

    if n = 0 then printfn "%d" x
    else
        let p = stdin.ReadLine().Split(' ') |> Array.map int
        fc x n p |> printfn "%d"

    0
