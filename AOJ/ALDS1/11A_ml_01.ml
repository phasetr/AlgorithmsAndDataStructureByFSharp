(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_11_A/review/5636622/que0/OCaml *)
let r = read_int ()
let m = Array.make_matrix r r 0;;
for i = 1 to r do
  let ir = Scanf.scanf "%d " (fun x -> x) in
  let nr = Scanf.scanf "%d " (fun x -> x) in
  for j = 1 to nr do
    Scanf.scanf "%d " (fun x -> m.(ir - 1).(x - 1) <- 1)
  done
done;
for i = 0 to (r -1 ) do
  print_int m.(i).(0);
  for j = 1 to (r - 1) do
    Printf.printf " %d" m.(i).(j)
  done;
  print_newline ()
done
