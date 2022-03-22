@"https://atcoder.jp/contests/agc031/tasks/agc031_a
- 1 \leq N \leq 100000
- S は英小文字からなる
- |S|=N"
#r "nuget: FsUnit"
open FsUnit

@"解説から:
空ではない全ての部分文字列が区別される.
同じ文字は使えないため,
ある文字cに対して条件をみたす取り方は(count c + 1).
全ての文字に対してこれを求め, 空文字の分を削ればよい."
let N,S = 4,"abcd"
let N,S = 3,"baa"
let solve N S =
    let mnum = pown 10 9 + 7 |> int64
    S |> Seq.countBy id
    |> Seq.map (fun (_,i) -> int64 i)
    |> Seq.fold (fun acc i -> (acc*(i+1L))%mnum) 1L
    |> fun x -> x-1L
let N = stdin.ReadLine() |> int
let S = stdin.ReadLine()
solve N S |> stdout.WriteLine

solve 4 "abcd" |> should equal 15
solve 3 "baa" |> should equal 5
solve 5 "abcab" |> should equal 17
