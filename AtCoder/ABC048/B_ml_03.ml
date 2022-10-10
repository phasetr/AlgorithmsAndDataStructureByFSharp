(* https://atcoder.jp/contests/abc048/submissions/14640650 *)
Scanf.scanf "%d %d %d" (fun a b x ->
    let ans = if a = 0 then b / x + 1 else b / x - (a - 1) / x in
    Printf.printf "%d\n" ans
  )
