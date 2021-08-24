let input = [|5;2;4;6;1;3|]

// x を後ろに送れるだけ送る関数
//asc 0 [|1; 3|] // -> [|0; 1; 3|]
//asc 2 [|1; 3|] // -> [|1; 2; 3|]
//asc 4 [|1; 3|] // -> [|1; 3; 4|]
let rec asc x ys =
  if Array.isEmpty ys then [|x|]
  else
    let z = ys.[0]
    let zs = ys.[1..]
    if x > z then Array.append [|z|] (asc x zs)
    else Array.append [|x|] ys

// 挿入ソート本体
let rec inssort xs ys =
  if Array.isEmpty ys then printfn "%A" xs // 最終結果
  else
    let z = ys.[0]
    let zs = ys.[1..]
    if Array.isEmpty xs then inssort [|z|] zs // 初期状態
    else
      // 途中経過
      printfn "%A" (Array.append xs ys)
      inssort (asc z xs) zs

inssort [||] input
