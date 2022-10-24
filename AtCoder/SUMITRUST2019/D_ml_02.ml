(* https://atcoder.jp/contests/sumitrust2019/submissions/8741908 *)
let rec fix f x = f (fix f) x
let ans =
  Scanf.scanf "%d %s" @@ fun n s ->
  let s = Array.init n (fun i -> Char.(code s.[i] - code '0')) in
  (0, 0) |> fix (fun f (i, a) ->
    if i >= 1000 then a else
    let d = [|i/100; i/10 mod 10; i mod 10|] in
    let b =
      (0, 0) |> fix (fun g (i, j) ->
        if j >= 3 then 1
        else if i >= n then 0
        else if d.(j) = s.(i) then g (i+1, j+1) else g (i+1, j))
    in f (i+1, a+b))
let _ = Printf.printf "%d\n" ans
