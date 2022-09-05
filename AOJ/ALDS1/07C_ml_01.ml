(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_7_C/review/1970511/superluminalsloth/OCaml *)
let nil = -1;;
type node =
  {
    mutable parent:int;
    mutable left:int;
    mutable right:int;
  };;

let tree = Array.init 25 (fun x -> { parent=nil; left=nil; right=nil; });;

let rec inorder = function
    i when i = nil -> ()
  | i ->
     inorder tree.(i).left;
     Printf.printf " %d" i;
     inorder tree.(i).right
;;

let rec preorder = function
    i when i = nil -> ()
  | i ->
     Printf.printf " %d" i;
     preorder tree.(i).left;
     preorder tree.(i).right
;;

let rec postorder = function
    i when i = nil -> ()
  | i ->
     postorder tree.(i).left;
     postorder tree.(i).right;
     Printf.printf " %d" i
;;

let rec get_root = function
    -1 -> nil
  | i -> if tree.(i).parent = nil then i
         else get_root (i-1)
;;

let rec read = function
    0 -> ()
  | i ->
     let (id,left,right) = Scanf.scanf " %d %d %d\n" (fun x y z -> (x,y,z)) in
     tree.(id).left <- left;
     tree.(id).right <- right;
     if left <> nil then tree.(left).parent <- id;
     if right <> nil then tree.(right).parent <- id;
     read (i-1)
;;

let () =
  let n = read_int () in
  read n;
  let root = get_root (n-1) in
  print_endline "Preorder";
  preorder root;print_newline();
  print_endline "Inorder";
  inorder root;print_newline();
  print_endline "Postorder";
  postorder root;print_newline()
;;
