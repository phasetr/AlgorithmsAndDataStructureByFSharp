// ## P.13 Challenge 7: Parson's Puzzle
// 本にあるプログラム断片を適切に並べ替える.
let subtract num1 num2 =
  if num1 <= num2 then num2 - num1
  else num1 - num2

subtract 1 2 |> printfn "%d"
subtract 2 1 |> printfn "%d"

let challenge07 =
  printfn "整数を入力してください."
  let num1_in = stdin.ReadLine() |> int
  printfn "整数を入力してください."
  let num2_in = stdin.ReadLine() |> int
  let difference = subtract num1_in num2_in
  printfn "The difference is %A" difference
//challenge07
