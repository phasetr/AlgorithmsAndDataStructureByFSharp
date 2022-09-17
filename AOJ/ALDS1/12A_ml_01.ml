(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_12_A/review/2446101/r6eve/OCaml *)
let prim a n =
  let min_costs = Array.make n max_int in
  min_costs.(0) <- 0;
  let reached_p = Array.make n false in
  let rec doit () =
    let u =
      Array.fold_left (fun (i, m, u) e ->
        if not reached_p.(i) && m > e then (i + 1, e, i) else (i + 1, m, u))
        (0, max_int, (-1)) min_costs
      |> (fun (_, _, u) -> u) in
    if u = (-1) then ()
    else begin
      reached_p.(u) <- true;
      for j = 0 to n - 1 do
        if a.(u).(j) <> (-1) && not reached_p.(j) && min_costs.(j) > a.(u).(j)
        then min_costs.(j) <- a.(u).(j);
      done;
      doit ()
    end in
  doit ();
  Array.fold_left (fun sum c -> if c = max_int then sum else sum + c) 0 min_costs

let () =
  let n = read_int () in
  let a = Array.make_matrix n n max_int in
  for i = 0 to n - 1 do
    for j = 0 to n - 1 do
      a.(i).(j) <- Scanf.scanf " %d" (fun x -> x);
    done
  done;
  prim a n |> Printf.printf "%d\n"
