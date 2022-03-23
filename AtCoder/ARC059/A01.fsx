@"https://atcoder.jp/contests/arc059/tasks/arc059_a
* 1≦N≦100
* -100≦a_i≦100"
#r "nuget: FsUnit"
open FsUnit

@"だいたい全体の数の「真ん中」で書き換えればよい.
Nが小さいから総当たりでもよさそう."
let N,Aa = 2,[|4;8|]
let solve N Aa =
    [|-100..100|]
    |> Array.map (fun x -> Aa |> Array.sumBy (fun a -> pown (x-a) 2))
    |> Array.min
let N = stdin.ReadLine() |> int
let Aa = stdin.ReadLine().Split() |> Array.map int
solve N Aa |> stdout.WriteLine

solve 2 [|4;8|] |> should equal 8
solve 3 [|1;1;3|] |> should equal 3
solve 3 [|4;2;5|] |> should equal 5
solve 4 [|-100;-100;-100;-100|] |> should equal 0
