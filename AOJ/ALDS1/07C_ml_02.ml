(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_7_C/review/2429840/r6eve/OCaml *)
let nil = -1

type t = { mutable parent : int; mutable left : int; mutable right : int }

let make () = { parent = nil; left = nil; right = nil }

let search_root t n =
  let rec doit i =
    if i = n then nil
    else if t.(i).parent = nil then i
    else doit (i + 1) in
  doit 0

let preorder t root f =
  let rec doit i =
    if i = nil then ()
    else begin
      f i;
      doit t.(i).left;
      doit t.(i).right
    end in
  doit root

let inorder t root f =
  let rec doit i =
    if i = nil then ()
    else begin
      doit t.(i).left;
      f i;
      doit t.(i).right
    end in
  doit root

let postorder t root f =
  let rec doit i =
    if i = nil then ()
    else begin
      doit t.(i).left;
      doit t.(i).right;
      f i
    end in
  doit root

let () =
  let n = read_int () in
  let t = Array.init n (fun _ -> make ()) in
  for _ = 0 to n - 1 do
    let (id, l, r) = Scanf.scanf "%d %d %d\n" (fun id l r -> (id, l, r)) in
    t.(id).left <- l;
    t.(id).right <- r;
    if l <> nil then t.(l).parent <- id;
    if r <> nil then t.(r).parent <- id;
  done;
  let root = search_root t n in
  print_endline "Preorder";
  preorder t root (fun i -> print_string " "; print_int i);
  print_newline ();
  print_endline "Inorder";
  inorder t root (fun i -> print_string " "; print_int i);
  print_newline ();
  print_endline "Postorder";
  postorder t root (fun i -> print_string " "; print_int i);
  print_newline ()
