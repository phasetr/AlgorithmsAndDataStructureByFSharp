(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_9_A/review/2434079/r6eve/OCaml *)
let parent i = int_of_float (floor (float_of_int i) /. 2.)
let left i = 2*i
let right i = 2*i + 1
let () =
  let h = read_int () in
  let t = Array.make (h + 1) 0 in
  for i = 1 to h do
    t.(i) <- Scanf.scanf "%d " (fun i -> i);
  done;
  for i = 1 to h do
    Printf.printf "node %d: key = %d, " i t.(i);
    if parent i >= 1 then Printf.printf "parent key = %d, " t.(parent i);
    if left i <= h then Printf.printf "left key = %d, " t.(left i);
    if right i <= h then Printf.printf "right key = %d, " t.(right i);
    print_newline ();
  done
