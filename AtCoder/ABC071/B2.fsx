#r "nuget: FsUnit"
open FsUnit

let solve S =
    let s = set S
    set "abcdefghijklmnopqrstuvwxyz"
    |> fun a -> a - s // 集合の差
    |> Set.toArray
    |> Array.sort
    |> fun a ->
        if a.Length = 0 then "None"
        else a.[0] |> string

stdin.ReadLine() |> solve |> printfn "%s"

solve "atcoderregularcontest" |> should equal "b"
solve "abcdefghijklmnopqrstuvwxyz" |> should equal "None"
solve "fajsonlslfepbjtsaayxbymeskptcumtwrmkkinjxnnucagfrg" |> should equal"d"
