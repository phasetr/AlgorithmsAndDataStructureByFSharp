// ## P.007 Challenge 1: Highest Number
// 3 つの数の中から最大の数を返す関数を作る
let highestNumber num1 num2 num3 =
  if num2 <= num1 && num3 <= num1 then num1
  else if num1 <= num2 && num3 <= num2 then num2
  else num3
// テスト
for i in [|1..3|] do
  for j in [|1..3|] do
    for k in [|1..3|] do
      printfn "(%A, %A, %A): %A" i j k (highestNumber i j k)

// ## P.008 Challenge 2: Calling Highest Number
let callHN =
  printfn "第一の数整値を入力してください."
  let num1In = stdin.ReadLine() |> int
  printfn "第二の数整値を入力してください."
  let num2In = stdin.ReadLine() |> int
  printfn "第三の数整値を入力してください."
  let num3In = stdin.ReadLine() |> int
  highestNumber num1In num2In num3In
// callHN |> printfn "最大値は次の数です: %A"
