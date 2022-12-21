// https://atcoder.jp/contests/abc146/submissions/8651464
[<AutoOpen>]
module Program
open System

let read f = stdin.ReadLine() |> f
let reada f = stdin.ReadLine().Split() |> Array.map f
let reads f = stdin.ReadLine().Split() |> Array.toList |> List.map f

[<EntryPoint>]
let main _ =
    let N = read int
    let ABS =
        List.init (N - 1) (fun i ->
            reads int
            |> fun [a;b] -> (a - 1, b - 1, i)
        )

    // eprintfn "ABS: %A" ABS

    let graph =
        let g = Array.init N (fun _ -> [])
        List.iter (fun (a, b, i) ->
            g.[a] <- (b, i) :: g.[a]
            g.[b] <- (a, i) :: g.[b]
        ) ABS
        Array.map List.toArray g

    // eprintfn "graph: %A" graph

    let ans = Array.create (N - 1) -1
    let rec dfs pid pcolor x =
        let mutable color = 1
        Array.iter (fun (a, i) ->
            if a <> pid then
                if color = pcolor then color <- color + 1
                ans.[i] <- color
                dfs x color a
                color <- color + 1
        ) graph.[x]

    graph
    |> Array.map Array.length
    |> Array.max
    |> printfn "%i"

    dfs -1 -1 0

    ans
    |> Array.iter (fun c -> printfn "%i" c)

    0
