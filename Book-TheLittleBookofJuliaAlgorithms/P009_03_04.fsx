// ## P.009 Challenge 3: Options
// 関数の引数ごとに次の文字列を返すようにする
//
// 1. Computer Science
// 2. Music
// 3. Dance
// 4. PE
//
// 上以外の入力の場合は Error を返すようにする
let options num =
  if num = 1 then "Computer Science"
  else if num = 2 then "Music"
  else if num = 3 then "Dance"
  else if num = 4 then "PE"
  else "Error"
[|1..6|]
|> Array.map (fun i -> sprintf "%A: %A" i (options i))
|> Array.map (fun s -> s |> printfn "%A")

// ## P.010 Challenge 4: Calling Options
// 上の options を呼ぶ処理を追加する
let callOptions =
  printfn "options を呼び出すために整数値を入力してください。"
  stdin.ReadLine() |> int |> options
// callOptions |> printfn "%A"
