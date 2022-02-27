@"https://atcoder.jp/contests/abc116/submissions/25804826"
#r "nuget: FsUnit"
open FsUnit

@"
main=interact$show.sum.(zipWith((max 0.).flip(-))=<<(0:)).tail.map read.words"
let solve N Hs =
    let flip f x y = f y x
    Array.append [|0|] Hs
    |> Array.map2 (fun x -> (max 0 x) )
let N = stdin.ReadLine() |> int
let Hs = stdin.ReadLine().Split() |> Array.map int
solve N Hs |> stdout.WriteLine

solve 4 [|1;2;2;1|] |> should equal 2
solve 5 [|3;1;2;3;1|] |> should equal 5
solve 8 [|4;23;75;0;23;96;50;100|] |> should equal 221
