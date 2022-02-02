@"https://atcoder.jp/contests/agc021/submissions/3086557"
#r "nuget: FsUnit"
open FsUnit

let solve N =
    Seq.map (string >> int) N
    |> fun xs ->
        let h = Seq.head xs
        let ts = Seq.tail xs
        let num = Seq.length ts
        if Seq.forall ((=) 9) ts then h + 9 * num
        else h - 1 + 9 * num
let N = stdin.ReadLine()
solve N |> stdout.WriteLine

solve "100" |> should equal 18
solve "9995" |> should equal 35
solve "3141592653589793" |> should equal 137
