// ## P.011 Challenge 5: Tracing If Statements
// ### Q1
// 関数の挙動, 特に if の挙動を調べる
let mysteryNumber num =
  if num < 5 then 8
  else if num < 3 then 8
  else if num = 3 then 3
  else num

mysteryNumber 8 |> printfn "%A" // 8
mysteryNumber 8 |> printfn "%A" // 8
mysteryNumber 12 |> printfn "%A" // 12
mysteryNumber 5 |> printfn "%A" // 5

// ### Q2
// 上の関数は冗長で 2 行削れる. どの 2 行が削れるか?
let mysteryNumber2 num =
  if num < 5 then 8
  else num

mysteryNumber2 8 |> printfn "%A"  // 8
mysteryNumber2 3 |> printfn "%A"  // 8
mysteryNumber2 12 |> printfn "%A" // 12
mysteryNumber2 5 |> printfn "%A"  // 5

// ### Q3
// 元の関数の 6-7 行目は 3 を入力したら 3 を返すようになっているが, 実際にはこうならない.
// 何故か説明してみよう.

// #### A
// 先に `if num < 5` の判定にはいってしまうため.

// ## P.12 Challenge 6: Refining
// Challenge 5 の関数を次のように書き換える.
//
// - `num = 3` のときに 1 を返す
// - `num` が 5 未満（かつ 3 でないとき）に 8 を返す
// - 上記以外は入力をそのまま返す
let mysteryNumber3 num =
  if num = 3 then num
  else if num < 5 then 8
  else num

[|0..12|]
|> Array.map (fun i -> sprintf "%A: %A" i (mysteryNumber3 i))
|> printfn "%A"
