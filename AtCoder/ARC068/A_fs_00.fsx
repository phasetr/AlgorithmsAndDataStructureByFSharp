#r "nuget: FsUnit"
open FsUnit

// let N,Aa = 5,[|1;2;1;3;7|]
// let N,Aa = 15,[|1;3;5;2;1;3;2;8;8;6;2;6;11;1;1|]
// 一行目: 各カードの枚数を数えて先に捨てられるだけ捨てる
// 二行目: 偶数枚あるカードの枚数で1引くかどうか処理をわける: これは具体例を見て挙動を決めた
let solve Aa =
  Aa |> Array.countBy id |> Array.map (fun (_,c) -> if c<3 then c elif c=3 then 1 else c%3+1)
  |> fun a -> let n = a |> Array.filter (fun x -> x%2=0) |> Array.length in if n%2=0 then a.Length else a.Length-1

// 解説を見てブラッシュアップ
// カードの山にk種類あるとして, kが奇数ならk, 偶数ならk-1
let solve Aa = Aa |> Array.distinct |> fun a -> let k = a.Length in if k%2=0 then k-1 else k

stdin.ReadLine() |> ignore
let Aa = stdin.ReadLine().Split() |> Array.map int
solve Aa |> stdout.WriteLine

// 一括処理
stdin.ReadLine() |> ignore
stdin.ReadLine().Split() |> Array.distinct |> (fun a -> let k = a.Length in if k%2=0 then k-1 else k) |> stdout.WriteLine

solve [|1;2;1;3;7|] |> should equal 3
solve [|1;3;5;2;1;3;2;8;8;6;2;6;11;1;1|] |> should equal 7
