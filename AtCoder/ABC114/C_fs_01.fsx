// https://atcoder.jp/contests/abc114/submissions/8524423
let n = stdin.ReadLine()

let all753 =
    let rec all753 i (strList:seq<string>) =
        if i > n.Length-1 then strList |> Seq.filter (fun x -> int x <= int n)
        else
            all753 (i+1)
                (strList |> Seq.collect (fun x ->
                    if x.Length <> i then
                        seq{yield x}
                    else
                    seq{yield x; yield ("7"+x); yield("5"+x); yield("3"+x)}))

    all753 1 ["7";"5";"3"]

let contain753 (str:string) = str.Contains "7" && str.Contains "5" && str.Contains "3"

all753 |> Seq.filter contain753 |> Seq.length |> stdout.WriteLine
