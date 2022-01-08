(*
問題文
ある合宿におやつとしてチョコレートが何個か準備されました。
合宿は N 人が参加して D 日間行われました。
i 人目の参加者 (1≤i≤N) は合宿の 1,Ai+1,2Ai+1,... 日目にチョコレートを 1 個ずつ食べました。
その結果、合宿終了後に残っていたチョコレートは X 個となりました。
また、合宿の参加者以外がチョコレートを食べることはありませんでした。

合宿開始前に準備されていたチョコレートの個数を求めてください。

制約
1≤N≤100
1≤D≤100
1≤X≤100
1≤Ai≤100 (1≤i≤N)
*)
#r "nuget: FsUnit"
open FsUnit

let takeLessThanD D a =
    Seq.initInfinite (fun x -> a * x + 1)
    |> Seq.takeWhile (fun x -> x <= D)

let solve N D X As =
    let lostChocolates =
        As
        |> Array.map (takeLessThanD D >> Seq.length)
        |> Array.sum
    X + lostChocolates

let N = stdin.ReadLine() |> int
let D, X = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
let As = [| for i in 1..N do (stdin.ReadLine() |> int) |]
solve N D X As |> printfn "%d"

takeLessThanD 7 2 |> should equal (seq [1;3;5;7])
takeLessThanD 7 5 |> should equal (seq [1;6])
takeLessThanD 7 10 |> should equal (seq [1])
solve 3 7 1 [| 2; 5; 10 |] |> should equal 8
solve 2 8 20 [| 1; 10 |]   |> should equal 29
solve 5 30 44 [| 26; 18; 81; 18; 6 |] |> should equal 56
