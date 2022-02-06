@"https://atcoder.jp/contests/abc144/tasks/abc144_c"
#r "nuget: FsUnit"
open FsUnit

@"何はともあれ因数分解が必要.
合成数の場合, 因数分解して適当に最小値を探す:
素因数分解まで行かなくてもよい: むしろ途中結果で十分.
Nが素数ならXかYのどちらかにだけ移動すればいい."

let solve N =
    let sqrtN = N |> float |> sqrt |> int64
    let xs = [|2L..sqrtN|] |> Array.filter (fun x -> x*x <= N && N%x=0L)
    if Array.isEmpty xs then N-1L
    else xs |> Array.map (fun x -> (x-1L) + (N/x - 1L)) |> Array.min
let N = stdin.ReadLine() |> int64
solve N |> stdout.WriteLine

solve 10L |> should equal 5L
solve 50L |> should equal 13L
solve 10000000019L |> should equal 10000000018L
