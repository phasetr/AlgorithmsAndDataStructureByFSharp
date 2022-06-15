(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_9_C/review/2446239/rabbisland/OCaml *)
let iref = ref 0
let parent i = i/2
let left i = 2*i
let right i = 2*i+1

let extract (t : int array) =
  let rec max_heapify i =
    let l = left i in
    let r = right i in
    let m = if l <= !iref && t.(i) < t.(l) then l else i in
    let m = if r <= !iref && t.(m) < t.(r) then r else m in
    if i = m then ()
    else begin
      let ti = t.(i) in
      t.(i) <- t.(m); t.(m) <- ti;
      max_heapify m
    end in
  let ret = t.(1) in
  t.(1) <- t.(!iref);
  decr iref;
  max_heapify 1;
  ret

let insert x (t : int array) =
  let rec frec i =
    let p = parent i in
    if i <= 1 || t.(i) <= t.(p) then ()
    else begin
      let ti = t.(i) in
      t.(i) <- t.(p);
      t.(p) <- ti;
      frec p
    end in
  incr iref;
  t.(!iref) <- x;
  frec !iref

let () =
  let t = Array.make 2000001 0 in
  let rec frec () =
    let op = Scanf.scanf "%s " (fun i -> i) in
    if op = "end" then ()
    else if op = "extract" then begin
      extract t |> Printf.printf "%d\n";
      frec ()
    end else begin
      insert (Scanf.scanf "%d " (fun i -> i)) t;
      frec ()
    end in
  frec ()
