@"https://atcoder.jp/contests/agc029/tasks/agc029_a
1 \leq |S| \leq 2\times 10^5
S_i=B または W"
#r "nuget: FsUnit"
open FsUnit

@"Wの前にBがある限り止まらない.
終わるのは全てのWがBの前に来るときで,
最後はWWW...BBB...の形になる.
各Wの前にある全てのBの数を数えて足し上げればいい.
再帰かfoldのどちらかで処理できる."
let solve S =
    let s = S |> List.ofSeq
    let rec f sum bNum s =
        match s with
        | [] -> sum
        | x::xs ->
            if x = 'W' then f (sum+bNum) bNum xs
            else f sum (bNum+1L) xs
    f 0L 0L s
let S = stdin.ReadLine()
solve S |> stdout.WriteLine

solve "BBW" |> should equal 2L
solve "BWBWBW" |> should equal 6L
