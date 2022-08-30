(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_6_B/review/2457814/r6eve/OCaml *)
let partition (a : int array) p r =
  let swap i j = let tmp = a.(i) in a.(i) <- a.(j); a.(j) <- tmp in
  let rec doit i j =
    if j = r then (swap i r; i)
    else if a.(j) <= a.(r) then (swap i j; doit (i + 1) (j + 1))
    else doit i (j + 1) in
  doit p p

let () =
  let n = read_int () in
  let a = Array.init n (fun _ -> Scanf.scanf "%d " (fun i -> i)) in
  let k = partition a 0 (n - 1) in
  Array.iteri (fun i e -> Printf.printf (if i = 0 then "%d" else if i = k then " [%d]" else " %d") e) a;
  print_newline ()
