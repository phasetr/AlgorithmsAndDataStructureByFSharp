(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_8_A/review/2010118/superluminalsloth/OCaml *)
type bs_tree = Nil | Node of node and
node = {
    key:int;
    mutable left:bs_tree;
    mutable right:bs_tree
  };;

let new_node key = {key=key;left=Nil;right=Nil};;

let insert t z =
  let rec loop y = function
      Nil -> y
    | Node x ->
       if z.key < x.key then
         loop (Node x) (x.left)
       else
         loop (Node x) (x.right)
  in
  let y = loop t t in
  match y with
    Nil -> (Node z)
  | Node y ->
     if z.key < y.key then
       y.left <- (Node z)
     else
       y.right <- (Node z)
    ;t
;;

let rec print_in = function
    Nil -> ()
  | Node x ->
     print_in (x.left);
     print_string " ";print_int  x.key;
     print_in (x.right)
;;

let rec print_pre = function
    Nil -> ()
  | Node x ->
     print_string " ";print_int x.key;
     print_pre (x.left);print_pre (x.right)
;;

let () =
  let n = read_int () in
  let rec read t = function
      0 -> ()
    | i ->
       let com = Scanf.scanf "%s" (fun x -> x) in
       if com = "insert" then begin
           let arg = Scanf.scanf " %d\n" (fun x -> x) in
           let z = new_node arg in
           read (insert t z) (i-1)
         end
       else if com = "print" then begin
           let _ = Scanf.scanf "%s\n" (fun x -> x) in
           print_in t;print_newline ();
           print_pre t;print_newline ();
           read t (i-1)
         end
       else ()
  in read Nil n
;;
