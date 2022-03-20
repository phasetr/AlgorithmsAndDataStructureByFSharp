@"https://atcoder.jp/contests/abc058/tasks/arc071_a
- 1 \leq n \leq 50
- i = 1, ... , n に対して、 1 \leq |S_i| \leq 50
- i = 1, ... , n に対して、 S_i は小文字のアルファベット(a - z )からなる文字列"
#r "nuget: FsUnit"
open FsUnit

@"各文字列を構成する文字の共通部分を取り,
辞書順の最小を取る."
let solve N Sa =
    Sa |> Array.map (Seq.countBy id >> Map)
    |> Array.reduce (fun acc m -> acc |> Map.map (fun k v -> if Map.containsKey k m then min v m.[k] else 0))
    |> Map.toArray
    |> Array.sortBy fst
    |> Array.fold (fun acc a -> Array.append acc (Array.create (snd a) (fst a |> string))) [|""|]
    |> String.concat ""
let N = stdin.ReadLine() |> int
let Sa = [| for i in 1..N do (stdin.ReadLine()) |]
solve N Sa |> stdout.WriteLine

solve 3 [|"cbaa";"daacc";"acacac"|] |> should equal "aac"
solve 3 [|"a";"aa";"b"|] |> should equal ""
