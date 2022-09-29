(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_14_B/review/2456655/r6eve/OCaml *)
let pn = 1000000007

let rec pow x n =
  if n = 0 then 1
  else if n mod 2 = 0 then pow (x * x) (n / 2)
  else x * pow (x * x) (n / 2)

let fold_left f init s n =
  let rec doit i acc =
    if i = n then acc
    else doit (i + 1) (f acc s.[i]) in
  doit 0 init

let () =
  let p = read_line () in
  let t = read_line () in
  let n = String.length p in
  let m = String.length t in
  let h = Array.make (n + 1) 0 in
  String.iteri (fun i c -> h.(i+1) <- h.(i)*pn + Char.code c) p;
  let ht = fold_left (fun acc c -> acc*pn + Char.code c) 0 t m in
  let x = pow pn m in
  for i = m to n do
    if h.(i) - h.(i-m)*x = ht then Printf.printf "%d\n" (i - m);
  done
