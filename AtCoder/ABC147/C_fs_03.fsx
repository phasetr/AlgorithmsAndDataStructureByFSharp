// https://atcoder.jp/contests/abc147/submissions/13171627
open System

let n = Console.ReadLine() |> int

let testimonies: (int * int) list list =
    [ for i in 1 .. n do
        let a = Console.ReadLine() |> int
        yield [ for j in 1 .. a do
                    let xy = Console.ReadLine().Split(' ') |> Array.map int
                    yield xy.[0] - 1, xy.[1] ] ]

let ans =
    let rec dfs is rest =
        match rest with
        | [] ->
            let set = Set is
            let mutable ok = true

            for i in is do
                for x, y in testimonies.[i] do
                    if y = 0 && set.Contains x then ok <- false
                    elif y = 1 && not (set.Contains x) then ok <- false

            if ok then List.length is else 0
        | i :: rest ->
            max (dfs is rest) (dfs (i :: is) rest)

    dfs [] [ 0 .. n - 1 ]

ans |> Console.WriteLine
