@"https://atcoder.jp/contests/abc151/submissions/17252578"
#r "nuget: FsUnit"
open FsUnit

let solve N M pss =
    let f (map: Map<int, int*int>) (i,c) =
    match (i, c, map.TryFind i) with
    | (num, "AC", None) ->
        // 初解答でAC: 正答フラグを立てる
        map.Add(num, (1,0))
    | (num, _, None) ->
        // 初解答でWA: 誤答数を立てる
        map.Add(num, (0,1))
    | (_, _, Some(1,_)) ->
        // 既にAC: 解答がACでもWAでも変更なし
        map
    | (num, "AC", Some(_,wa)) ->
        // 既に解答があり初AC: 誤答数を保持しつつ正答フラグを立てる
        map.Add(num, (1,wa))
    | (num, _, Some(_, wa)) ->
        // 既に解答がり正解なし: 誤答数を追加
        map.Add(num, (0,wa+1))
    pss
    |> Array.fold f Map.empty
    |> Map.fold (fun (ac,wa) _ (ac1,wa1) ->
        if ac1 = 0 then (ac,wa) else (ac+ac1,wa+wa1)) (0,0)

let N, M = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
let pss = [| for i in 1..M do (stdin.ReadLine().Split() |> fun x -> (int x.[0], x.[1])) |]
solve N M pss |> fun (ac,wa) -> printfn "%d %d" ac wa

solve 2 5 [|(1,"WA");(1,"AC");(2,"WA");(2,"AC");(2,"WA")|] |> should equal (2,2)
solve 100000 3 [|(7777,"AC");(7777,"AC");(7777,"AC")|] |> should equal (1,0)
solve 6 0 [||] |> should equal (0,0)
