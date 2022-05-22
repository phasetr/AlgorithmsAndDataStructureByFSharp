#r "nuget: FsUnit"
open FsUnit

@"https://atcoder.jp/contests/dp/submissions/14843484"
@"A=0, B=1, C=2として,
「dp[i][j] = i日目に行動jを取ったときの最大値」を計算してたたみ込む."
let solve N Hs =
    let help acc x =
        match (acc,x) with
        | ([|accA;accB;accC|], [|a;b;c|]) ->
            [|a + (max accB accC); b + max accC accA; c + max accA accB|]
        | _ -> [|0;0;0|] // ここには来ない
    Hs
    |> Array.fold help [|0;0;0|]
    |> Array.max

let N = stdin.ReadLine() |> int
let Hs = [| for i in 1..N do (stdin.ReadLine().Split() |> Array.map int) |]
solve N Hs |> stdout.WriteLine

solve 3 [|[|10;40;70|];[|20;50;80|];[|30;60;90|]|] |> should equal 210
solve 1 [|[|100;10;1|]|] |> should equal 100
solve 7 [|[|6;7;8|];[|8;8;3|];[|2;5;2|];[|7;8;6|];[|4;6;8|];[|2;3;4|];[|7;5;1|]|] |> should equal 46
