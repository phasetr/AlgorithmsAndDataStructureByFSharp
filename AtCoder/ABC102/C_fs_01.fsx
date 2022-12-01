// https://atcoder.jp/contests/abc102/submissions/2823883
let n = int(stdin.ReadLine())
let a = stdin.ReadLine().Split(' ') |> Array.mapi (fun i s -> int64(int(s)-i-1))
let b = a |> Seq.sort |> Seq.item (n/2)
a |> Seq.sumBy (fun x -> abs(x-b)) |> stdout.WriteLine
