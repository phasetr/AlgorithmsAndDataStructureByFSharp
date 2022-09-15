(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_11_C/review/2014760/r6eve/OCaml *)
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
  let d = Array.make n (-1) in
  let q = Queue.create () in
  let rec duduwa i = function
    | [] -> ()
    | hd :: tl when d.(hd-1) = (-1) -> (d.(hd-1) <- d.(i) + 1; Queue.add (hd-1) q; duduwa i tl)
    | _ :: tl -> duduwa i tl
  and doit () =
    if not (Queue.is_empty q) then begin
      let i = Queue.take q in
      duduwa i g.(i);
      doit ()
    end
  in
  Queue.add 0 q;
  d.(0) <- 0;
  doit ();
  let rec print i =
    if i < n then (Printf.printf "%d %d\n" (i + 1) d.(i); print (i + 1))
  in
  print 0;
