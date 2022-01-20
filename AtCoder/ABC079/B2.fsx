@"https://atcoder.jp/contests/abc079/submissions/17209855"
#r "nuget: FsUnit"
open FsUnit

let lucasNumber n =
    let rec inner i memo =
        if i > n then memo
        else inner (i+1) (memo @ [memo.[i-1] + memo.[i-2]])
    inner 2 [2UL;1UL] |> fun a -> a.[n]
stdin.ReadLine() |> int |> lucasNumber |> stdout.WriteLine

lucasNumber 5 |> should equal 11UL
lucasNumber 86 |> should equal 939587134549734843UL
