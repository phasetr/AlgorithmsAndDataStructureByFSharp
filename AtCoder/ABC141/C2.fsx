@"https://atcoder.jp/contests/abc141/submissions/23690406"
#r "nuget: FsUnit"
open FsUnit

// 可変配列を使って書き換え
let solve N K Q As =
    let mutable AC = Array.replicate N 0
    As
    |> Array.map int
    |> Array.map (fun x -> AC.[x-1] <- AC.[x-1] + 1) |> ignore
    AC |> Array.map (fun x -> if K-Q+x > 0 then "Yes" else "No")

let N, K, Q = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1], x.[2])
let As = [| for i in 1..N do (stdin.ReadLine() |> int) |]
solve N K Q As |> String.concat " "

solve 6 3 4 [|3; 1; 3; 2|] |> should equal [|"No"; "No"; "Yes"; "No"; "No"; "No"|]
solve 6 5 4 [|3; 1; 3; 2|] |> should equal [|"Yes"; "Yes"; "Yes";"Yes"; "Yes"; "Yes"|]
solve 10 13 15 [|3;1;4;5;9;2;6;5;3;5;8;9;7;9|] |> should equal [|"No";"No";"No";"No";"Yes";"No";"No";"No";"Yes";"No"|]
