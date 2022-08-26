(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_5_A/review/2458188/r6eve/OCaml *)
let max_m = 2000

let make_dp a n =
  let dp = Array.make_matrix (n + 1) (max_m + 1) false in
  for i = 1 to n do dp.(i).(a.(i-1)) <- true done;
  for i = 2 to n do
    for j = 1 to max_m do
      if dp.(i-1).(j) || j > a.(i-1) && dp.(i-1).(j - a.(i-1)) then dp.(i).(j) <- true;
    done;
  done;
  dp

let () =
  let n = Scanf.scanf "%d " (fun i -> i) in
  let a = Array.init n (fun _ -> Scanf.scanf "%d " (fun i -> i)) in
  let dp = make_dp a n in
  let q = Scanf.scanf "%d " (fun i -> i) in
  for _ = 0 to q - 1 do
    Printf.printf "%s\n" (if dp.(n).(Scanf.scanf "%d " (fun i -> i)) then "yes" else "no")
  done
