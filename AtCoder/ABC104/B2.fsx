@"https://atcoder.jp/contests/abc104/submissions/18844232"
#r "nuget: FsUnit"
open FsUnit

let solve (s: string) =
    (s.[0] = 'A'
     && s.[2..s.Length - 2]
        |> Seq.filter ((=) 'C')
        |> Seq.length
        |> (=) 1
     && s.[1..]
        |> Seq.except [| 'C' |]
        |> Seq.forall (System.Char.IsLower))
    |> function
    | true -> "AC"
    | false -> "WA"

stdin.ReadLine() |> solve |> stdout.WriteLine

solve "AtCoder" |> should equal "AC"
solve "ACoder" |> should equal "WA"
solve "AcycliC" |> should equal "WA"
solve "AtCoCo" |> should equal "WA"
solve "Atcoder" |> should equal "WA"
