(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_9_A/review/5535110/que0/OCaml *)
let n = read_int ()
let h = Array.make (n + 1) 0;;
for i = 1 to n do
  Scanf.scanf "%d " (fun x -> h.(i) <- x)
done;
for i = 1 to n do
  Printf.printf "node %d: key = %d, " i h.(i);
  if i >= 2 then Printf.printf "parent key = %d, " h.(i / 2);
  if i * 2 <= n then Printf.printf "left key = %d, " h.(i * 2);
  if i * 2 + 1 <= n then Printf.printf "right key = %d, " h.(i * 2 + 1);
  Printf.printf "\n"
done
