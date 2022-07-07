(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_6_B/review/2963457/napo/OCaml *)
let () =
  let s = Array.make 13 false in
  let h = Array.make 13 false in
  let c = Array.make 13 false in
  let d = Array.make 13 false in
  let n = read_int () in
  for i = 1 to n do
    let (a, j) = Scanf.scanf "%c %d\n" (fun x y -> (x, y - 1)) in
    match a with
    | 'S' -> s.(j) <- true
    | 'H' -> h.(j) <- true
    | 'C' -> c.(j) <- true
    | 'D' -> d.(j) <- true
    | _   -> ()
  done;
  let f c = Array.iteri (fun i v -> if not v then Printf.printf "%c %d\n" c (i + 1) else ()); in
  f 'S' s;
  f 'H' h;
  f 'C' c;
  f 'D' d;
;;

