(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_8_A/review/2083753/r6eve/OCaml *)
type tree = Nil | Node of int * tree * tree

let create () = Nil

let insert x t =
  let rec doit = function
    | Nil -> Node (x, Nil, Nil)
    | Node (y, l, r) when x < y -> Node (y, doit l, r)
    | Node (y, l, r) -> Node (y, l, doit r) in
  doit t

let preorder f t =
  let rec doit = function
    | Nil -> ()
    | Node (x, l, r) -> f x; doit l; doit r in
  doit t

let inorder f t =
  let rec doit = function
    | Nil -> ()
    | Node (x, l, r) -> doit l; f x; doit r in
  doit t

let print t =
  let f e = print_string " "; print_int e in
  inorder f t;
  print_newline ();
  preorder f t;
  print_newline ()

let split_on_char sep s =
  let open String in
  let r = ref [] in
  let j = ref (length s) in
  for i = length s - 1 downto 0 do
    if get s i = sep then begin
        r := sub s (i + 1) (!j - i - 1) :: !r;
        j := i
      end
  done;
  sub s 0 !j :: !r

let () =
  let m = read_int () in
  let rec read i t =
    if i < m then
      match split_on_char ' ' (read_line ()) with
      | ["insert"; n] -> read (i + 1) (insert (int_of_string n) t)
      | _ -> print t; read (i + 1) t in
  read 0 (create ())
