@"https://atcoder.jp/contests/code-festival-2017-qualb/tasks/code_festival_2017_qualb_b
1 \leq N \leq 200,000
1 \leq D_i \leq 10^9
1 \leq M \leq 200,000
1 \leq T_i \leq 10^9
入力される値は全て整数である"
#r "nuget: FsUnit"
open FsUnit

@"T_i達がD_iの部分列になっていればよい.
まずM<=Nが必要.
以下のコードはAtCoderでエラー: Map.changeがないと言われる.
バージョンの問題か."
let N,Ds,M,Ts = 5,[|3;1;4;1;5|],3,[|5;4;3|]
let solveError N Ds M Ts =
    if N<=M then "NO"
    else
        let ds = Ds |> Array.countBy id |> Map
        Ts |> Array.fold (fun state t ->
            Map.change t (fun x ->
                match x with
                | Some(s) -> Some(s-1)
                | None -> Some(-1)) state) ds
        |> Map.forall (fun _ s -> 0 <= s)
        |> fun b -> if b then "YES" else "NO"

let solveError2 N Ds M Ts =
    let f = function
        | Some s -> Some (s-1)
        | None -> Some(-1)
    let g (state: Map<int,int>) (t: int) = state.Change (t,f)

    if N<=M then "NO"
    else
        let ds = Ds |> Array.countBy id |> Map
        Ts |> Array.fold g ds
        |> Map.forall (fun _ s -> 0 <= s)
        |> fun b -> if b then "YES" else "NO"

let N = stdin.ReadLine() |> int
let Ds = stdin.ReadLine().Split() |> Array.map int
let M = stdin.ReadLine() |> int
let Ts = stdin.ReadLine().Split() |> Array.map int
solve N Ds M Ts |> stdout.WriteLine

solve 5 [|3;1;4;1;5|] 3 [|5;4;3|] |> should equal "YES"
solve 7 [|100;200;500;700;1200;1600;2000|] 6 [|100;200;500;700;1600;1600|] |> should equal "NO"
solve 1 [|800|] 5 [|100;100;100;100;100|] |> should equal "NO"
solve 15 [|1;2;2;3;3;3;4;4;4;4;5;5;5;5;5|] 9 [|5;4;3;2;1;2;3;4;5|] |> should equal "YES"
