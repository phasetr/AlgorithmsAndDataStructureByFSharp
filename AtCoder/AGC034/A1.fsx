@"https://atcoder.jp/contests/agc034/tasks/agc034_a
- 4 \leq N \leq 200,000
- S は ., # からなる長さ N の文字列
- 1 \leq A, B, C, D \leq N
- マス目 A, B, C, D に岩は置かれていない
- A, B, C, D はすべて異なる
- A < B
- A < C
- B < D"
#r "nuget: FsUnit"
open FsUnit

@"稼働範囲の中に#が連続して存在していたらその時点でアウト.
C<DならBを動かしてからAを動かせばよい.
D<CならBを障害物判定する必要があり,
稼働範囲に三つ連続した`.`があればよい.
参考: https://atcoder.jp/contests/agc034/submissions/17495044"
let solve N A B C D (S: string) =
    let toString s = s |> Seq.map string |> String.concat ""
    let search (s: string) i j =
        S |> Seq.take j |> Seq.skip (i-1) |> toString
        |> fun t -> if t.IndexOf(s) = -1 then false else true
    let areaCheck i j = not (search "##" i j)
    let dotsCheck = if C<D then true else search "..." (B-1) (D+1)
    if areaCheck A C && areaCheck B D && dotsCheck then "Yes" else "No"

let N,A,B,C,D = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1], x.[2], x.[3], x.[4])
let S = stdin.ReadLine()
solve N A B C D S |> stdout.WriteLine

solve 7 1 3 6 7 ".#..#.." |> should equal "Yes"
solve 7 1 3 7 6 ".#..#.." |> should equal "No"
solve 15 1 3 15 13 "...#.#...#.#..." |> should equal "Yes"
