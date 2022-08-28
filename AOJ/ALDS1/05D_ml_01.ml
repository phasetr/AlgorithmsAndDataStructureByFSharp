(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_5_D/review/2426659/r6eve/OCaml *)
let cnt = ref 0

let merge a l m r =
  let x = m - l in
  let ai = Array.make (x + 1) max_int in
  for i = 0 to x - 1 do
    ai.(i) <- a.(l + i)
  done;
  let aj = Array.make (r - m + 1) max_int in
  for i = 0 to r - m - 1 do
    aj.(i) <- a.(m + i)
  done;
  let i = ref 0 in
  let j = ref 0 in
  for k = l to r - 1 do
    if ai.(!i) <= aj.(!j) then begin
        a.(k) <- ai.(!i);
        incr i;
      end else begin
        a.(k) <- aj.(!j);
        cnt := !cnt + (x - !i);
        incr j;
      end
  done

let rec merge_sort a l r =
  if (l + 1) >= r then () else
    let m = (l + r) / 2 in
    merge_sort a l m;
    merge_sort a m r;
    merge a l m r

let () =
  let n = read_int () in
  let a = Array.init n (fun _ -> Scanf.scanf "%d " (fun i -> i)) in
  merge_sort a 0 n;
  Printf.printf "%d\n" !cnt
