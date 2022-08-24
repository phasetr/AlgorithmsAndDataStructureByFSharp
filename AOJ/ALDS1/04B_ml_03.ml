(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_4_B/review/5499024/que0/OCaml *)
let rec bs f a s e x =
  if s >= e
  then false
  else
    let m = (s + e) / 2 in
    match f x a.(m) with
    | 0 -> true
    | p when p < 0 -> bs f a s m x
    | p -> bs f a (m+1) e x

let si _ = Scanf.scanf "%d " (fun a -> a)
let n = si 0;;
let s = Array.make n 0;;
for i = 0 to n-1 do
  s.(i) <- (si 0)
done;;
let q = si 0
let a = ref 0;;
for i=1 to q do
  if (bs compare s 0 n (si 0)) then a := !a + 1
done;;
Printf.printf "%d\n" !a

