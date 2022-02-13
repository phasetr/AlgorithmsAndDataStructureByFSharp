@"https://atcoder.jp/contests/agc029/tasks/agc029_a
1 \leq |S| \leq 2\times 10^5
S_i=B または W"
#r "nuget: FsUnit"
open FsUnit

let solve S =
    S
    |> Seq.fold(fun (sum, bNum) s ->
        if s = 'W' then (sum+bNum, bNum)
        else (sum, bNum+1L)) (0L,0L)
    |> fst

let S = stdin.ReadLine()
solve S |> stdout.WriteLine

solve "BBW" |> should equal 2L
solve "BWBWBW" |> should equal 6L
