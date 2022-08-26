(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_5_B/review/2192455/ydash/OCaml *)
let counter = ref 0

let merge array left mid right =
  let init n p = Array.init (n+1) (fun i -> if i=n then max_int else array.(p+i)) in
  let xs = init (mid-left) left in
  let ys = init (right-mid) mid in
  let rec loop i j k =
    if k < right then
      (incr counter;
       if xs.(i) <= ys.(j) then (array.(k) <- xs.(i); loop (i+1) j (k+1))
       else (array.(k) <- ys.(j); loop i (j+1) (k+1)))
  in loop 0 0 left

let rec msort array left right =
  if left+1 < right then
    let mid = (left+right)/2 in
    msort array left mid;
    msort array mid right;
    merge array left mid right

let () =
  let n = read_int () in
  let (l : int array) = Array.init n (fun _ -> Scanf.scanf "%d " (fun x -> x)) in
  msort l 0 n;
  Array.iteri (fun i v -> Printf.printf (if i = n-1 then "%d\n" else "%d ") v) l;
  Printf.printf "%d\n" !counter
