(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_7_C/review/4465827/tt99kuze/OCaml *)
let () =
  let r, c = Scanf.scanf "%d %d\n" (fun x y -> x,y) in
  let d = Array.make_matrix (r+1) (c+1) 0 in
  for i = 0 to (r-1) do
    for j = 0 to (c-1) do
      d.(i).(j) <- Scanf.scanf "%d " (fun x -> x);
      d.(i).(c) <- d.(i).(c) + d.(i).(j);
      d.(r).(j) <- d.(r).(j) + d.(i).(j);
      Printf.printf "%d " d.(i).(j)
    done;
    Printf.printf "%d\n" d.(i).(c);
    d.(r).(c) <- d.(r).(c) + d.(i).(c)
  done;
  for j = 0 to (c-1) do
    Printf.printf "%d " d.(r).(j)
  done;
    Printf.printf "%d\n" d.(r).(c);;
