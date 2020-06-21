(*
巨大な数を扱うとき
cf: https://atcoder.jp/contests/abc169/tasks/abc169_b
例えば積がオーバーフローするかしないかを判定するとき、
積の値そのものを確認するのではなく、
オーバーフローチェックすべき値を新たにかける値で割った値で判定する。
*)
/// a: 元の値、b: 新たにかける値、n: オーバーフローチェックする値
/// int なら int の範囲内で計算を処理できる
let checkOverflowGood a b n = a > (n / b)
/// a*b が int を飛び越えるとき、オーバーフローしてマイナスになったりする
let checkOverflowBad a b n = n < (a * b)

// check
System.Int32.MaxValue |> printfn "%d"
System.Int32.MaxValue * 2 |> printfn "%d"

checkOverflowBad System.Int32.MaxValue 2 System.Int32.MaxValue
|> printfn "%b"
