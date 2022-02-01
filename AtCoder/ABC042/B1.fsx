@"https://atcoder.jp/contests/abc042/tasks/abc042_b"
#r "nuget: FsUnit"
open FsUnit

let solve N L Ss = Array.sort Ss |> String.concat ""
let N, L = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
let Ss = [| for i in 1..N do (stdin.ReadLine()) |]
solve N L Ss |> stdout.WriteLine

solve 3 3 [|"dxx";"axx";"cxx"|] |> should equal "axxcxxdxx"
