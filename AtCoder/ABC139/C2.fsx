@"https://atcoder.jp/contests/abc139/submissions/23708012"
#r "nuget: FsUnit"
open FsUnit

let rec solve N (Hs: array<int>) i acc v =
    if i = N then acc
    else
        if Hs.[i] > Hs.[i-1] then solve N Hs (i+1) acc 0
        else solve N Hs (i + 1) (max acc (v+1)) (v+1)

let N = stdin.ReadLine() |> int
let Hs = stdin.ReadLine().Split() |> Array.map int
solve N Hs 1 0 0 |> printfn "%d"

solve 5 [|10;4;8;7;3|] 1 0 0 |> should equal 2
solve 7 [|4;4;5;6;6;5;5|] 1 0 0 |> should equal 3
solve 4 [|1;2;3;4|] 1 0 0 |> should equal 0
