@"https://atcoder.jp/contests/code-festival-2016-quala/tasks/codefestival_2016_qualA_b"
#r "nuget: FsUnit"
open FsUnit

"2≤N≤10^5
1≤a_i≤N
a_i≠i
a_{a_i} = iをみたす要素の数を調べればよい.
必ずペアで出てくるので割り算しないとペア数が出ないことに注意.
F#の配列のindexと与えられた値のずれにも注意する."
let solve N As =
    As |> Array.mapi (fun i x -> (i,x))
    |> Array.filter (fun (i,x) -> As.[x-1] = i+1)
    |> fun x -> (Array.length x) / 2

let N = stdin.ReadLine() |> int
let As = stdin.ReadLine().Split() |> Array.map int
solve N As |> stdout.WriteLine

solve 4 [|2;1;4;3|] |> should equal 2
solve 3 [|2;3;1|] |> should equal 0
solve 5 [|5;5;5;5;1|] |> should equal 1
