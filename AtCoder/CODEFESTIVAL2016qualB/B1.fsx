// https://atcoder.jp/contests/code-festival-2016-qualb/tasks/codefestival_2016_qualB_b
// https://atcoder.jp/contests/code-festival-2016-qualb/submissions/13488953
let n, a, b =
    let l = stdin.ReadLine().Split(' ') |> Array.map int
    l.[0], l.[1], l.[2]

let s = stdin.ReadLine()

[ 0 .. s.Length - 1 ]
|> List.scan (fun (pass, bCnt, msg) i ->
    let c = s.[i]
    match c with
    | 'a' -> if pass < a + b then (pass + 1, bCnt, "Yes") else (pass, bCnt, "No")
    | 'b' -> if pass < a + b && bCnt < b then (pass + 1, bCnt + 1, "Yes") else (pass, bCnt + 1, "No")
    | _ -> (pass, bCnt, "No")) (0, 0, "")
|> List.iter (fun (_, _, msg) -> stdout.WriteLine msg)
