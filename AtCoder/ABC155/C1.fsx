@"https://atcoder.jp/contests/abc155/tasks/abc155_c
問題文
N 枚の投票用紙があり、i (1≤i≤N) 枚目には文字列 Si が書かれています。
書かれた回数が最も多い文字列を全て、
辞書順で小さい順に出力してください。

制約
1≤N≤2×10^5
Si は英小文字のみからなる文字列 (1≤i≤N)
Si の長さは 1 以上 10 以下 (1≤i≤N)"
#r "nuget: FsUnit"
open FsUnit

let solve N Ss =
    let xs = Ss |> Array.groupBy id |> Array.map (fun (k,v) -> (k, Array.length v))
    let m = Array.fold (fun acc (_,num) -> max acc num) 0 xs
    Array.filter (fun (k,v) -> v = m) xs
    |> Array.map (fun (k,_) -> k)
    |> Array.sort
let N = stdin.ReadLine() |> int
let Ss = [| for i in 1..N do stdin.ReadLine() |]
solve N Ss |> String.concat "\n" |> stdout.WriteLine

solve 7 [|"beat";"vet";"beet";"bed";"vet";"bet";"beet"|] |> should equal [|"beet";"vet"|]
solve 8 [|"buffalo";"buffalo";"buffalo";"buffalo";"buffalo";"buffalo";"buffalo";"buffalo"|] |> should equal [|"buffalo"|]
solve 7 [|"bass";"bass";"kick";"kick";"bass";"kick";"kick";|] |> should equal [|"kick"|]
solve 4 [|"ushi";"tapu";"nichia";"kun"|] |> should equal [|"kun";"nichia";"tapu";"ushi"|]
