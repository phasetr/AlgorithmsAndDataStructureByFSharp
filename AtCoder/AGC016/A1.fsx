@"
https://atcoder.jp/contests/agc016/tasks/agc016_a
1 ≤ |s| ≤ 100
s は英小文字のみからなる。"
#r "nuget: FsUnit"
open FsUnit

@"一番多い文字を選んであとは潰していけばよい.
リスト化して再帰を書き処理を進める.

ここでは文字の短さを前提に解説に準じて,
全ての文字に対してそれへの変換を計算して最小を取る."
let solve s =
    let rec f acc c t =
        let l = List.length t
        if l = 1 then acc
        elif List.countBy id t |> List.length = 1 then acc
        else
            [0..(l-2)] |> List.map (fun i ->
                if t.[i] = c || t.[i+1] = c then c else t.[i])
            |> f (acc+1) c
    let t = Seq.toList s
    ['a'..'z'] |> List.map (fun c -> f 0 c t) |> List.min
let s = stdin.ReadLine()
solve s |> stdout.WriteLine

solve "serval" |> should equal 3
solve "jackal" |> should equal 2
solve "zzz" |> should equal 0
solve "whbrjpjyhsrywlqjxdbrbaomnw" |> should equal 8
