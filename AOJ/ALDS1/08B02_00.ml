(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_8_B/review/2433450/r6eve/OCaml *)
type tree = Nil | Node of int * tree * tree

let create () = Nil

let insert x t =
  let rec frec = function
    | Nil -> Node (x, Nil, Nil)
    | Node (y, l, r) -> if x < y then Node (y, frec l, r) else Node (y, l, frec r)
  in frec t

let print_preorder f t =
  let rec frec = function
    | Nil -> ()
    | Node (x, l, r) -> f x; frec l; frec r in
  frec t

let print_inorder f t =
  let rec frec = function
    | Nil -> ()
    | Node (x, l, r) -> frec l; f x; frec r in
  frec t

let print t =
  print_inorder (fun e -> print_string " "; print_int e) t;
  print_newline ();
  print_preorder (fun e -> print_string " "; print_int e) t;
  print_newline ()

let find x t =
  let rec frec = function
    | Nil -> false
    | Node (y, l, r) -> if x = y then true else if x < y then frec l else frec r
  in frec t

let () =
  let n = read_int () in
  let t = ref (create ()) in
  for _ = 0 to n-1 do
    match (Str.split (Str.regexp " +") (read_line ())) with
    | "insert" :: n :: _ -> t := insert (int_of_string n) !t
    | "find" :: n :: _ -> print_endline (if find (int_of_string n) !t then "yes" else "no")
    | _ -> print !t
  done
