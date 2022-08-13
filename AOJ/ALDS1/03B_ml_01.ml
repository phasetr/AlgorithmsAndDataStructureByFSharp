(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_3_B/review/2042169/ydash/OCaml *)
let () =
  let open Queue in
  let (n:int),(quantum:int) = Scanf.scanf "%d %d\n" (fun a b -> a,b) in
  let (q:(string * int) t) = create () in
  for i=1 to n do
    add (Scanf.scanf "%s %d\n" (fun a b -> a,b)) q
  done;
  let (sum:int ref) = ref 0 in
  while not (is_empty q) do
    let p,t = take q in
    if t <= quantum then (sum := !sum+t; Printf.printf "%s %d\n" p !sum)
    else (add (p,t-quantum) q; sum := !sum+quantum)
  done
