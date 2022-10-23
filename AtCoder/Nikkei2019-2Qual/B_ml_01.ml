(* https://atcoder.jp/contests/nikkei2019-2-qual/submissions/16523239 *)
let md = 998244353

let pow a b =
  let rec f a b c =
    if b = 0 then c
    else if (b land 1) = 1 then f (a * a mod md) (b lsr 1) (c * a mod md)
    else f (a * a mod md) (b lsr 1) c
  in f a b 1

let solve2 a m =
  let rec f i v ans =
    if i = m + 1 then ans
    else f (i + 1) a.(i) (ans * pow v a.(i) mod md)
  in f 0 1 1

let solve n d =
  let a = Array.make n 0 in
  let m = Array.fold_left (fun m d -> a.(d) <- a.(d) + 1; max m d) 0 d in
  if a.(0) = 1 then solve2 a m else 0

let () =
  let n = read_int() in
  let d = Array.init n (fun _ -> Scanf.scanf " %d" (fun i -> i)) in
  let ans = if d.(0) = 0 then solve n d else 0 in
  Printf.printf "%d\n" ans
