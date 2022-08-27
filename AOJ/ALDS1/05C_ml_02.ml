(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_5_C/review/5509322/que0/OCaml *)
open Complex

let p_p p = Printf.printf "%f %f\n" p.re p.im;;

let rec kc n p1 p2 = (
  if n > 0
  then (
    let ls = div (sub p2 p1) {re=3.;im=0.} in
    let s = add p1 ls and t = sub p2 ls in
    let u = add s (mul ls (pow i{re=2./.3.;im=0.})) in
    let m = n-1 in
    kc m p1 s; kc m s u; kc m u t; kc m t p2 )
  else p_p p2 )
;;
p_p zero;;
kc (read_int ()) zero {re=100.;im=0.}
