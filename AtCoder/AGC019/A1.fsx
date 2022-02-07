@"https://atcoder.jp/contests/agc019/tasks/agc019_a"
#r "nuget: FsUnit"
open FsUnit

@"小数の処理を避けたいから,
Q=25, H=50, S=100, D=200でN*100の分割を考えればよい?
出てくる数は巨大なので単純な全探索は使えないはず.

Qが奇数だと絶対に買い切れないからQは絶対に偶数.
最終的には整数値にしなければいけないから,
QとHで賄う分は整数値にならなければならず,
QとHは使うなら「Qが4つ」か「Qが2つでHが1つ」.
まとめれば1を作る方法は4Q or 2Q+1H or Sで,
最小金額だけがほしいからこれの最小値で計算すればいい.

以下, 1を作る金額(の最小値)をs,
2を作る金額をd(=D)とする.

Nが偶数のとき.
全て2sかdかでよく, これの最小値を計算して適切に処理すればよい.

Nが奇数のとき.
上記と同じように処理できる."
let solve Q H S D N =
    let s = Array.min [|4L*Q; 2L*Q+H; 2L*H; S|]
    let d = D
    match (2L*s <= d, N%2L=0L) with
    | (true, _)      -> s*N // 全部シングル
    | (false, true)  -> d * (N/2L) // 全部ダブル
    | (false, false) -> d * ((N-1L)/2L) + s

let [|Q;H;S;D|] = stdin.ReadLine().Split() |> Array.map int64
let N = stdin.ReadLine() |> int64
solve Q H S D N |> stdout.WriteLine

solve 20L 30L 70L 90L 3L |> should equal 150L
solve 10000L 1000L 100L 10L 1L |> should equal 100L
solve 10L 100L 1000L 10000L 1L |> should equal 40L
solve 12345678L 87654321L 12345678L 87654321L 123456789L |> should equal 1524157763907942L
