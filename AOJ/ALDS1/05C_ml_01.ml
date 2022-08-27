(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_5_C/review/2195012/ydash/OCaml *)
let pi = 4. *. atan 1.

let d60 = pi /.  3.

let printer (a,b) = Printf.printf "%f %f\n" a b

let f (a,b) (c,d) = (2. *. a +. c) /. 3., (2. *. b +. d) /. 3.

let rec recursive depth p1 p2 =
  if depth=0 then ()
  else
    let ((sx,sy) as s) = f p1 p2 in
    let ((tx,ty) as t) = f p2 p1 in
    let tsx = tx -. sx in
    let tsy = ty -. sy in
    let u = tsx *. cos d60 -. tsy *. sin d60 +. sx,
            tsx *. sin d60 +. tsy *. cos d60 +. sy in
    let d = depth-1 in
    recursive d p1 s;
    printer s;
    recursive d s u;
    printer u;
    recursive d u t;
    printer t;
    recursive d t p2

let () =
  let depth = read_int () in
  let p1 = 0.,0. in
  let p2 = 100., 0. in
  printer p1;
  recursive depth p1 p2;
  printer p2
