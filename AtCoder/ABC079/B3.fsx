@"https://atcoder.jp/contests/abc079/submissions/2825088"
#r "nuget: FsUnit"
open FsUnit

let Lucas =
    Seq.unfold (fun (prevprev, prev) ->
                let current = prevprev + prev
                in Some (current, (prev, current))) (3L, -1L)

let n = stdin.ReadLine() |> int
Seq.item n Lucas |> stdout.WriteLine

Seq.item 5 Lucas |> should equal 11L
Seq.item 86 Lucas |> should equal 939587134549734843L
