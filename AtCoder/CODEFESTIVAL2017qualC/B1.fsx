@"https://atcoder.jp/contests/code-festival-2017-qualc/tasks/code_festival_2017_qualc_b"
#r "nuget: FsUnit"
open FsUnit

@"先頭が偶数なら残りは3パターン全て取れる.
先頭が奇数なら偶数にずらして残りは3パターン全て取れる.
(動的計画法で解ける?)"
let solve N As =
    let allOddNum = (1,As) ||> Array.fold (fun acc x -> if x%2=0 then acc*2 else acc)
    (pown 3 N) - allOddNum

let N = stdin.ReadLine() |> int
let As = stdin.ReadLine().Split() |> Array.map int
solve N As |> stdout.WriteLine

solve 2 [|2;3|] |> should equal 7
solve 3 [|3;3;3|] |> should equal 26
solve 1 [|100|] |> should equal 1
solve 10 [|90;52;56;71;44;8;13;30;57;84|] |> should equal 58921
