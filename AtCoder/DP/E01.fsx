@"https://atcoder.jp/contests/dp/tasks/dp_e"
#r "nuget: FsUnit"
open FsUnit

@"https://atcoder.jp/contests/dp/submissions/27032331"
@"dp[i][j]=(i番目までの品物を価値がjになるように選んだときの最小重さ)"
@"初期化
必要なテーブル: 現在の配列(不変), 一つ先の配列(内側のループで生成)
結果: 一つ先の配列の末尾
foldで渡す必要があるdpは現在の配列(不変)だけ."
let chmax wvs dp i v =
    let (w0,v0) = Array.item i wvs
    let s =
        if v - v0 >= 0 then Array.item (v - v0) dp |> Option.map ((+) w0)
        else None
    let nots = Array.item v dp
    match s, nots with
    | Some w, Some w' -> min w w' |> Some
    | Some w, None -> Some w
    | None, Some w' -> Some w'
    | _ -> None

let solve N W wvs =
    let f wvs v dp i = chmax wvs dp i |> Array.init v
    let find = function
        | Some w0 -> w0 <= W
        | None -> false

    let v = 1 + Array.sumBy snd wvs
    let dp = (fun i -> if i = 0 then Some 0L else None) |> Array.init v

    Array.fold (f wvs v) dp [|0..N-1|]
    |> Array.findIndexBack find

let N, W = stdin.ReadLine().Split() |> (fun x -> int x.[0], int64 x.[1])
let wvs = [| for i in 1..N do (stdin.ReadLine().Split() |> fun x -> int64 x.[0], int x.[1]) |]
solve N W wvs |> stdout.WriteLine

solve 3 8L [|(3L,30);(4L,50);(5L,60)|] |> should equal 90
solve 1 1000000000L [|(1000000000L,10)|] |> should equal 10
solve 6 15L [|(6L,5);(5L,6);(6L,4);(6L,6);(3L,5);(7L,2)|] |> should equal 17
