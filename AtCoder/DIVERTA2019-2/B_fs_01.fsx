//  https://atcoder.jp/contests/diverta2019-2/submissions/7968799
[<AutoOpen>]
module Program

open System

let read f = stdin.ReadLine() |> f
let reada f = stdin.ReadLine().Split() |> Array.map f
let reads f = stdin.ReadLine().Split() |> Array.toList |> List.map f

[<EntryPoint>]
let main _ =
    let N = read int
    let xys = List.init N (fun _ -> reads int |> fun [x;y] -> (x,y))

    let vecs =
        List.collect (fun (x1, y1) ->
            List.map (fun (x2, y2) ->
                (x2 - x1, y2 - y1)
            ) xys
        ) xys
        |> List.filter ((<>) (0, 0))

    let len =
        List.map (fun (vx, vy) ->
            List.sumBy (fun (x1, y1) ->
                List.filter (fun (x2, y2) ->
                    vx = x2 - x1 && vy = y2 - y1
                ) xys
                |> List.length
            ) xys
        ) vecs

    if N = 1 then
        printfn "1"
    else
        printfn "%i" (N - List.max len)
    0
