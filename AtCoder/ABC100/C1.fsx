@"https://atcoder.jp/contests/abc100/tasks/abc100_c"
#r "nuget: FsUnit"
open FsUnit

let solve N As =
    let rec div2num n acc =
        if n%2 = 0 then div2num (n/2) acc+1
        else acc
    Array.fold (fun acc x -> (div2num x 0) + acc) 0 As
let N = stdin.ReadLine() |> int
let As = stdin.ReadLine().Split() |> Array.map int
solve N As |> stdout.WriteLine

div2num 2 0 |> should equal 1
div2num 3 0 |> should equal 0
div2num 4 0 |> should equal 2
div2num 5 0 |> should equal 0
div2num 6 0 |> should equal 1
div2num 7 0 |> should equal 0
div2num 8 0 |> should equal 3
div2num 9 0 |> should equal 0

solve 3 [|5;2;4|] |> should equal 3
solve 4 [|631;577;243;199|] |> should equal 0
solve 10 [|2184;2126;1721;1800;1024;2528;3360;1945;1280;1776|] |> should equal 39


