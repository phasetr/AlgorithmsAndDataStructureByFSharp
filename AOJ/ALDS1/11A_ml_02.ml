(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_11_A/review/2438199/r6eve/OCaml *)
let () =
  let n = read_int () in
  let a = Array.make_matrix n n 0 in
  for _ = 0 to n - 1 do
    let (id, k) = Scanf.scanf "%d %d " (fun id k -> (id, k)) in
    for _ = 0 to k - 1 do
      a.(id-1).(Scanf.scanf "%d " (fun i -> i) - 1) <- 1
    done
  done;
  for i = 0 to n - 1 do
    for j = 0 to n - 1 do
      Printf.printf (if j = 0 then "%d" else " %d") a.(i).(j)
    done;
    print_newline ()
  done
