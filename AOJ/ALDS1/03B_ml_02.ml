(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_3_B/review/2426111/r6eve/OCaml *)
let () =
  let open Queue in
  let (que : (string * int) Queue.t) = create () in
  let (n, q) = Scanf.scanf "%d %d\n" (fun n q -> (n, q)) in
  for _ = 0 to n - 1 do
    add (Scanf.scanf "%s %d\n" (fun s t -> s, t)) que;
  done;
  let cnt = ref 0 in
  while not (is_empty que) do
    let (s, t) = take que in
    let rest = t - q in
    if rest <= 0 then begin
      cnt := !cnt + t;
      Printf.printf "%s %d\n" s !cnt;
    end else begin
      add (s, rest) que;
      cnt := !cnt + q;
    end
  done
