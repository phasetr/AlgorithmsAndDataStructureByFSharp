let input1 = [|5;3;1;3;4;3|]
let input2 = [|4;3;2|]

let rec solve1 (a: int array) maxv =
  if Array.length a = 1 then maxv
  else
    let v = a.[0]
    let a1 = a.[1..]
    let m = Array.map (fun x -> x-v) a1 |> Array.max
    solve a1 (max m maxv)

let renew (maxv, minv) v =
  (max maxv (v - minv), min minv v)

let solve2 (a: int array) =
  let maxv = -2000
  let minv = a.[0]
  // ループをはじめる位置に注意
  Array.fold renew (maxv, minv) a.[1..] |> fst

solve1 input1 -2000 = 3
solve1 input2 -2000 = -1
solve2 input1 = 3
solve2 input2 = -1
