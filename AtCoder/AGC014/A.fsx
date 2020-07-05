// https://atcoder.jp/contests/agc014/tasks/agc014_a
// 無限回操作できる条件について：必要十分条件は A=B=C。
// 解説：https://img.atcoder.jp/agc014/editorial.pdf
// A=B=C のときに無限回操作できることは自明。
// 逆の場合を考える。
// 操作後の値は (A+B)/2, (B+C)/2, (C+A)/2 である。
// A \leq B \leq C を仮定すると、
// クッキーの個数の最大値と最小値の差は操作前は C-A、操作後は (C-A)/2 で、
// 操作によって最大・最小の差は 1/2 になる。
// A=B=C でないとすると、操作は高々 log_2 M 回しか続かない。
let rec judge a b c acc =
    if a % 2 = 1 || b % 2 = 1 || c % 2 = 1
    then acc
    elif a = b && b = c
    then -1
    else judge ((b + c) / 2) ((c + a) / 2) ((a + b) / 2) (acc + 1)

//let input = [| [| 4; 12; 20 |]; [| 14; 14; 14 |]; [| 454; 414; 444 |] |]
//for i in input do (judge i.[0] i.[1] i.[2] 0 |> printfn "%d")
// expected 3; -1; 1
[<EntryPoint>]
let main argv =
    stdin.ReadLine().Split()
    |> Array.map int
    |> fun x -> judge x.[0] x.[1] x.[2] 0
    |> printfn "%d"
    0
