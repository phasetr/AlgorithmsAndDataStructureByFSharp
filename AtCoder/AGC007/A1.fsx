@"https://atcoder.jp/contests/agc007/tasks/agc007_a
- 2 \leq H, W \leq 8
- a_{i,j} は # または . である。
- 問題文および a で与えられる情報と整合するような駒の動き方が存在する。"
#r "nuget: FsUnit"
open FsUnit

@"WA.
以下のコメントの解き方だと001.txtが通らない.
https://www.dropbox.com/sh/nx3tnilzqz7df8a/AAB3byeuaDJQofH5fq1nmduua/AGC007/A/in?dl=0&preview=001.txt&subfolder_nav_tracking=1
で, この入力は次の通り.

8 8
#.......
#.......
#.......
#......#
########
.......#
.......#
.......#

前の列の最後の#の位置と現在行の最初の#の位置が同じならよい."
let H,W,Aa=4,5,[|"##...";".##..";"..##.";"...##"|]
let solve H W (Aa:array<string>) =
    ((true,0),Aa) ||> Array.fold (fun (b,blnum) s ->
        if not b then (false, 0)
        else
            if blnum <> firstnum then (false, 0)
            else
                let lastnum = (blnum-1) + (s.[blnum..] |> Seq.takeWhile (fun c -> c = '#') |> Seq.length)
                (true, lastnum))
    |> fun (b,_) -> if b then "Possible" else "Impossible"
let H,W = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
let Aa = [| for i in 1..H do stdin.ReadLine() |]
solve H W Aa |> stdout.WriteLine

solve 4 5 [|"##...";".##..";"..##.";"...##"|] |> should equal "Possible"
solve 5 3 [|"###";"..#";"###";"#..";"###"|] |> should equal "Impossible"
solve 4 5 [|"##...";".###.";".###.";"...##"|] |> should equal "Impossible"
