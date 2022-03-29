@"https://atcoder.jp/contests/agc002/tasks/agc002_b
* 2≤N≤10^5
* 1≤M≤10^5
* 1≤x_i，y_i≤N
* x_i≠y_i
* i 回目の操作の直前、x_i 番目の箱には 1 個以上のボールが入っている。"
#r "nuget: FsUnit"
open FsUnit

@"1からどこにボールが遷移したかを考える.
途中でボールがなくなった場合, そこにいる可能性はなくなる.
解説から: ボールの数よりもコップに赤い水を汲んで,
その赤の色がどう伝播するか考えた方がわかりやすい.

Haskellコード群を見てみても,
破壞的な処理をかませた方がよさそう."
let N,M,Aa = 3,2,[|(1,2);(2,3)|]
let solve N M (Aa:array<int*int>) =
    let nums = Array.create N 1
    let reds = [|1..N|] |> Array.map (fun i -> if i=1 then true else false)
    ((nums,reds), [|0..M-1|])
    ||> Array.fold (fun (accnums,accreds) i ->
        let xi,yi = (fst Aa.[i] - 1, snd Aa.[i] - 1)
        if accreds.[xi] then Array.set accreds yi true else ()
        Array.set accnums xi (accnums.[xi]-1)
        Array.set accnums yi (accnums.[yi]+1)
        if accnums.[xi]=0 then Array.set accreds xi false else ()
        (accnums,accreds))
    |> fun (accnums, accreds) ->
        accreds |> Array.filter id |> Array.length
let N,M = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
let Aa = [| for i in 1..M do (stdin.ReadLine().Split() |> (fun x -> int x.[0], int x.[1])) |]
solve N M Aa |> stdout.WriteLine

solve 3 2 [|(1,2);(2,3)|] |> should equal 2
solve 3 3 [|(1,2);(2,3);(2,3)|] |> should equal 1
solve 4 4 [|(1,2);(2,3);(4,1);(3,4)|] |> should equal 3
