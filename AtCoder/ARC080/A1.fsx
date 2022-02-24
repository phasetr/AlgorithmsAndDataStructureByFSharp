@"https://atcoder.jp/contests/arc080/tasks/arc080_a
2 ≤ N ≤ 10^5
a_i は整数である。
1 ≤ a_i ≤ 10^9"
#r "nuget: FsUnit"
open FsUnit

@"いったん前から考える.
奇数の次は問答無用で4の倍数が必要.
偶数の場合, 既に4の倍数なら次は任意で,
2の倍数でしかないなら次に偶数が必要.
結局a_iは1か2か4かの場合だけに帰着する.
1-4-1-4と並べ続けてあとは2だけならよく,
1の次に2が来たらアウト."
let solve N Aa =
    ((0,0,0), Aa) ||> Array.fold (fun (odd, two, four) a ->
        if a%4=0 then (odd,two,four+1)
        elif a%2=0 then (odd,two+1,four)
        else (odd+1,two,four))
    |> fun (odd,two,four) ->
        if odd <= four then "Yes"
        else if odd+four=N && odd=four+1 then "Yes" else "No"

let N = stdin.ReadLine() |> int
let Aa = stdin.ReadLine().Split() |> Array.map int
solve N Aa |> stdout.WriteLine

solve 3 [|1;10;100|] |> should equal "Yes"
solve 4 [|1;2;3;4|] |> should equal "No"
solve 3 [|1;4;1|] |> should equal "Yes"
solve 2 [|1;1|] |> should equal "No"
solve 6 [|2;7;1;8;2;8|] |> should equal "Yes"
