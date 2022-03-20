@"https://atcoder.jp/contests/abc058/submissions/13921074"
#r "nuget: FsUnit"
open FsUnit

let solve N Sa =
    let S = Sa |> Array.map (Seq.countBy id >> Map)
    "abcdefghijklmnopqrstuvwxyz"
    |> Seq.collect (fun c ->
        let count = List.min [ for counter in S -> if counter.ContainsKey c then Map.find c counter else 0 ]
        Array.init count (fun _ -> c))
    |> Seq.map string |> String.concat ""
let N = stdin.ReadLine() |> int
let Sa = [| for i in 1..N do (stdin.ReadLine()) |]
solve N Sa |> stdout.WriteLine

solve 3 [|"cbaa";"daacc";"acacac"|] |> should equal "aac"
solve 3 [|"a";"aa";"b"|] |> should equal ""
