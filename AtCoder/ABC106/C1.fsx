@"https://atcoder.jp/contests/abc106/tasks/abc106_c"
#r "nuget: FsUnit"
open FsUnit

let ctoi c = c |> string |> int
let itos i = Seq.replicate i (string i) |> String.concat ""
let sconv s =
    Seq.map (fun c -> c |> ctoi |> itos) s
    |> String.concat ""
ctoi '1' |> should equal 1
ctoi '2' |> should equal 2
itos 1 |> should equal "1"
itos 2 |> should equal "22"
sconv "1" |> should equal "1"
sconv "2" |> should equal "22"
sconv "123" |> should equal "122333"

@"S.[0..K-1]が全て1なら1,
それ以外は全てS中にはじめて出てくる2以上の文字."
let solve S K =
    // K<=100かつSの長さがK以上あって全て1かどうか
    let chk (S: string) K =
        if 100L < K then false
        else
            let k = int K
            (k <= min 100 (String.length S))
            && (S.[0..k-1] = (Seq.replicate k "1" |> String.concat ""))
    let notOneChar S =
        S |> Seq.filter (fun c -> c <> '1') |> Seq.head

    if chk S K then '1' else notOneChar S

let S = stdin.ReadLine()
let K = stdin.ReadLine() |> int64
solve S K |> stdout.WriteLine

solve "1214" 4L |> should equal '2'
solve "3" 157L |> should equal '3'
solve "299792458" 9460730472580800L |> should equal '2'
