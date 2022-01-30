@"https://atcoder.jp/contests/abc128/tasks/abc128_b
問題文
あなたは美味しいレストランを紹介する本を書くことにしました。
あなたは N 個のレストラン、レストラン 1、レストラン 2、…、レストラン N を紹介しようとしています。
レストラン i は Si 市にあり、あなたは 100 点満点中 Pi 点と評価しています。
異なる 2 個のレストランに同じ点数がついていることはありません。

この本では、次のような順でレストランを紹介しようとしています。

市名が辞書順で早いものから紹介していく。
同じ市に複数レストランがある場合は、点数が高いものから紹介していく。
この本で紹介される順にレストランの番号を出力してください。

制約
1≤N≤100
S は英小文字のみからなる長さ 1 以上 10 以下の文字列
0≤Pi≤100
Pi は整数
Pi \neq Pj (1≤i<j≤N)"
#r "nuget: FsUnit"
open FsUnit

@"
- indexをつけて元の並び順を記録する
- groupByで市ごとにまとめる
- 市名でソートする
- 市ごとに点数で降順ソートする
- 元の並び順を取りつつflattenする"
let solve N sps =
    sps |> Array.indexed
    |> Array.groupBy (fun (_,(city,_)) -> city)
    |> Array.sortBy (fun (city,_) -> city)
    |> Array.map (fun (_,v) -> v |> Array.sortByDescending (fun (_,(_,score)) -> score))
    |> Array.collect (fun x -> x |> Array.map (fun (idx,_) -> idx+1))
let N = stdin.ReadLine() |> int
let sps = [| for i in 1..N do (stdin.ReadLine().Split() |> fun x -> x.[0], int x.[1]) |]
solve N sps |> Array.map string |> String.concat "\n" |> stdout.WriteLine

solve 6 [|("khabarovsk",20);("moscow",10);("kazan",50);("kazan",35);("moscow",60);("khabarovsk",40)|] |> should equal [|3;4;6;1;5;2|]
solve 10 [|("yakutsk",10);("yakutsk",20);("yakutsk",30);("yakutsk",40);("yakutsk",50);("yakutsk",60);("yakutsk",70);("yakutsk",80);("yakutsk",90);("yakutsk",100)|] |> should equal [|10;9;8;7;6;5;4;3;2;1|]
