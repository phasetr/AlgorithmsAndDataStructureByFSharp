(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_7_B/review/1933805/superluminalsloth/OCaml *)
let nil = -1;;
type node =
  {
    mutable parent:int;
    mutable left:int;
    mutable right:int;
    mutable height:int;
    mutable depth: int
  };;

let tree = Array.init 25 (fun x -> { parent=nil; left=nil; right=nil; height=0; depth=0 });;

let rec set_height u =
  let h1 = if tree.(u).right != nil then set_height tree.(u).right + 1 else 0
    and
      h2 = if tree.(u).left != nil then set_height tree.(u).left + 1 else 0
  in
  let hmax = if h1 > h2 then h1 else h2 in
  tree.(u).height <- hmax; hmax
;;

let rec set_depth u d =
  if u != nil then
    begin
      tree.(u).depth <- d;
      set_depth tree.(u).left (d+1);
      set_depth tree.(u).right (d+1)
    end
;;

let rec get_root = function
    -1 -> nil
  | i -> if tree.(i).parent = nil then i
         else get_root (i-1)
;;

let get_sibling u =
  if tree.(u).parent = nil then nil
  else if tree.(tree.(u).parent).left != u && tree.(tree.(u).parent).left != nil then
    tree.(tree.(u).parent).left
  else if tree.(tree.(u).parent).right != u && tree.(tree.(u).parent).right != nil then
    tree.(tree.(u).parent).right
  else nil
;;

let rec read = function
    0 -> ()
  | i ->
     let l = read_line ()
             |> Str.split (Str.regexp " ")
             |> List.map int_of_string
             |> Array.of_list
     in
     tree.(l.(0)).left <- l.(1);
     tree.(l.(0)).right <- l.(2);
     if l.(1) != nil then tree.(l.(1)).parent <- l.(0);
     if l.(2) != nil then tree.(l.(2)).parent <- l.(0);
     read (i-1)
;;

let print_node u =
  Printf.printf "node %d: " u;
  Printf.printf "parent = %d, " tree.(u).parent;
  Printf.printf "sibling = %d, " (get_sibling u);
  let ldeg = if tree.(u).left != nil then 1 else 0 and
      rdeg = if tree.(u).right != nil then 1 else 0 in
  Printf.printf "degree = %d, "  (ldeg+rdeg);
  Printf.printf "depth = %d, " tree.(u).depth;
  Printf.printf "height = %d, " tree.(u).height;
  if tree.(u).parent = nil then Printf.printf "root\n"
  else if tree.(u).left = nil && tree.(u).right = nil then Printf.printf "leaf\n"
  else Printf.printf "internal node\n"
;;

let () =
  let n = read_int () in
  read n;
  let root = get_root (n-1) in
  set_depth root 0;
  let _ = set_height root in
  let rec print = function
      i when i = n -> ()
    | i -> print_node i; print (i+1)
  in print 0
;;
