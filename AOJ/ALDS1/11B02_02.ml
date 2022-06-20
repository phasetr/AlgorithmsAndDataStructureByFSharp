(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_11_B/review/2014675/r6eve/OCaml *)
let () =
  let n = read_int () in
  let g = Array.make n [] in
  let rec read i =
    if i < n then
      match List.map int_of_string (Str.split (Str.regexp " ") (read_line ())) with
      | u :: _ :: l -> (g.(u-1) <- l; read (i + 1))
      | _ -> exit 1
  in
  read 0;
  let d = Array.make n 0 in
  let f = Array.make n 0 in
  let time = ref 1 in
  let rec dudu = function
    | [] -> ()
    | hd :: tl when d.(hd-1) = 0 -> (wa (hd - 1); dudu tl)
    | _ :: tl -> dudu tl
  and wa i =
    d.(i) <- !time; incr time;
    dudu g.(i);
    f.(i) <- !time; incr time
  and doit i =
    if i < n then (if d.(i) = 0 then wa i; doit (i + 1))
  in
  doit 0;
  let rec print i =
    if i < n then (Printf.printf "%d %d %d\n" (i + 1) d.(i) f.(i); print (i + 1))
  in
  print 0;
