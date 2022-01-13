#r "nuget: FsUnit"
open System
open System.IO
open FsUnit

// 公式解説から
let solve a b c d =
    let x = c-a
    let y = d-b
    [c-y; d+x; a-y; b+x]

let x1, y1, x2, y2 = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1], x.[2], x.[3])
solve x1 y1 x2 y2
|> List.map string |> String.concat " " |> printfn "%s"

solve 0 0 0 1 |> should equal [-1; 1; -1; 0]
solve 2 3 6 6 |> should equal [3; 10; -1; 7]
solve 31 -41 -59 26 |> should equal [-126; -64; -36; -131]
