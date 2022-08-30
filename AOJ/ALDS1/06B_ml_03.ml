(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_6_B/review/5517668/que0/OCaml *)
let asw a i j =
  let b = a.(i) in a.(i) <- a.(j); a.(j) <- b

let partition a p r =
  let x = a.(r) in
  let i = ref (p - 1) in
  for j = p to r - 1 do
    if a.(j) <= x
    then (i := !i + 1; asw a !i j);
  done;
  asw a (!i+1) r;
  !i+1

let m = read_int() - 1
let a = Array.init (m + 1) (fun _ -> Scanf.scanf "%d " (fun x -> x))

let pp = partition a 0 m
let pf = Printf.printf;;
for i = 0 to pp-1 do pf "%d " a.(i) done;
pf "[%d]" a.(pp);
for i = pp + 1 to m do pf " %d" a.(i) done;
print_newline ()
