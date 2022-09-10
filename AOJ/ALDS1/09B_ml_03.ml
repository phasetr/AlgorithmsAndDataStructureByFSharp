(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_9_B/review/2434113/r6eve/OCaml *)
let parent i = int_of_float (floor (float_of_int i) /. 2.)
let left i = 2*i
let right i = 2*i + 1

let build_max_heap (t : int array) h =
  let rec max_heapify i =
    let l = left i in
    let r = right i in
    let m = if l <= h && t.(l) > t.(i) then l else i in
    let m = if r <= h && t.(r) > t.(m) then r else m in
    if i = m then ()
    else
      let tmp = t.(i) in
      t.(i) <- t.(m);
      t.(m) <- tmp;
      max_heapify m in
  for i = parent h downto 1 do
    max_heapify i
  done

let () =
  let h = read_int () in
  let t = Array.make (h + 1) 0 in
  for i = 1 to h do
    t.(i) <- Scanf.scanf "%d " (fun i -> i)
  done;
  build_max_heap t h;
  for i = 1 to h do
    print_string " "; print_int t.(i)
  done;
  print_newline ()
