(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_9_C/review/2434193/r6eve/OCaml *)
let last_i = ref 0

let parent i = int_of_float (floor (float_of_int i) /. 2.)

let left i = 2*i

let right i = 2*i + 1

let extract (t : int array) =
  let rec max_heapify i =
    let l = left i in
    let r = right i in
    let m = if l <= !last_i && t.(l) > t.(i) then l else i in
    let m = if r <= !last_i && t.(r) > t.(m) then r else m in
    if i = m then ()
    else begin
      let tmp = t.(i) in
      t.(i) <- t.(m);
      t.(m) <- tmp;
      max_heapify m
    end in
  let ret = t.(1) in
  t.(1) <- t.(!last_i);
  decr last_i;
  max_heapify 1;
  ret

let insert x (t : int array) =
  let rec doit i =
    let p = parent i in
    if i <= 1 || t.(p) >= t.(i) then ()
    else begin
      let tmp = t.(i) in
      t.(i) <- t.(p);
      t.(p) <- tmp;
      doit p
    end in
  incr last_i;
  t.(!last_i) <- x;
  doit !last_i

let () =
  let t = Array.make 2000001 0 in
  let rec doit () =
    let op = Scanf.scanf "%s " (fun i -> i) in
    if op = "end" then ()
    else if op = "extract" then begin
      extract t |> Printf.printf "%d\n";
      doit ()
    end else begin
      insert (Scanf.scanf "%d " (fun i -> i)) t;
      doit ()
    end in
  doit ()
