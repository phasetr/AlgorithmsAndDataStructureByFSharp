@"https://atcoder.jp/contests/abc124/submissions/17207602"
#r "nuget: FsUnit"
open FsUnit

let solve (S: string) =
    let s = S.ToCharArray() |> Array.indexed
    let head = s.[0] |> snd
    let even =  s |> Array.filter(fun (index,c) -> index%2 = 0 && c<>head) |> Array.length
    let odd = s |> Array.filter(fun (index,c) -> index%2 = 1 && c=head) |> Array.length
    even+odd

let S = stdin.ReadLine()
solve S |> stdout.WriteLine

solve "000" |> should equal 1
solve "10010010" |> should equal 3
solve "0" |> should equal 0
