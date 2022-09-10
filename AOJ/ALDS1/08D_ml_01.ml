(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_8_D/review/5535055/que0/OCaml *)
type 'a tree = Nil | Tree of 'a
type wood = {key: int; pr: int; left: wood tree ; right: wood tree}

type tree_cmd = Cnil | Sup_left of wood | Sup_right of wood | As_is of wood
type tree_cmd2 = C2nil | C2nd of (int -> unit) * wood | C2tr of wood tree

let wood k p l r = {key = k; pr = p; left = l; right = r}
let tree k p l r  = Tree (wood k p l r)

let wood_of_tree = (function Tree w -> w | Nil -> raise (Failure "wood_of_tree"))
let iif cd tv fv = if cd then tv fv

let rightRotate t =
  match t with
  | Tree {key = ky; pr = py; left = Tree wx; right = c} ->
    tree  wx.key wx.pr wx.left (tree ky py wx.right c)
  | t -> t

let leftRotate t =
  match t with
  | Tree {key = kx; pr = px; left = a; right = Tree wy} ->
    tree  wy.key wy.pr (tree kx px a wy.left) wy.right
  | t -> t

let insert_s t zw =
  let stk = Stack.create () in
  Stack.push Cnil stk;
  let rec ins_p t =
    match t with
    | Nil -> Tree zw
    | Tree tw ->
      match (compare zw.key tw.key) with
      | 0 -> Nil
      | x when x < 0 -> (Stack.push (Sup_left tw) stk; ins_p tw.left)
      | x -> (Stack.push (Sup_right tw) stk; ins_p tw.right) in
  let rec recon_t t =
    match (Stack.pop stk) with
    | Sup_left w ->
      let rt = tree w.key w.pr t w.right in
      recon_t (if w.pr < (wood_of_tree t).pr then rightRotate rt else rt)
    | Sup_right w ->
      let rt = tree w.key w.pr w.left t in
      recon_t (if w.pr < (wood_of_tree t).pr then leftRotate rt else rt)
    | Cnil -> t
    | As_is w -> Tree w in
  match ins_p t with
  | (Tree _) as zt -> recon_t zt
  | Nil -> t

let rec find t k =
  match t with
  | Nil -> "no"
  | Tree w ->
    match (compare k w.key) with
    | 0 -> "yes"
    | x when x < 0 -> find w.left k
    | _ -> find w.right k

let delete_s t k =
  let stk = Stack.create () in
  Stack.push Cnil stk;
  let rec del_p t =
    match t with
    | Nil -> Nil
    | Tree tw ->
      match (compare k tw.key) with
      | 0 -> Tree tw
      | x when x < 0 -> (Stack.push (Sup_left tw) stk; del_p tw.left)
      | _ -> (Stack.push (Sup_right tw) stk; del_p tw.right) in
  let rec del_t t=
     match t with
     | Tree tw -> (
       match tw.left, tw.right with
       | Nil, Nil -> Nil
       | lt, Nil ->
         let rctw = wood_of_tree (rightRotate t) in
         (Stack.push (Sup_right rctw) stk; del_t rctw.right)
       | Nil, rt ->
         let rctw = wood_of_tree (leftRotate t) in
         (Stack.push (Sup_left rctw) stk; del_t rctw.left)
       | lt, rt when (wood_of_tree lt).pr > (wood_of_tree rt).pr ->
         let rctw = wood_of_tree (rightRotate t) in
         (Stack.push (Sup_right rctw) stk; del_t rctw.right)
       | lt, rt ->
         let rctw = wood_of_tree (leftRotate t) in
         (Stack.push (Sup_left rctw) stk; del_t rctw.left) )
     | Nil -> Nil
in
  let rec recon_t t =
    match (Stack.pop stk) with
    | Sup_left w ->
      let rt = recon_t (tree w.key w.pr t w.right) in rt
    | Sup_right w ->
      let rt = recon_t (tree w.key w.pr w.left t) in rt
    | Cnil -> t
    | As_is w -> Tree w in
  match del_p t with
  | (Tree _) as zt -> (del_t zt) |> (fun x -> recon_t x)
  | Nil -> t

let walk_print_s t f1 f2 f3=
  let stk2 = Stack.create () in
  Stack.push C2nil stk2;
  Stack.push (C2tr t) stk2;
  let rec w_p ()=
    match Stack.pop stk2 with
    | C2tr t -> (
      match t with
      | Nil -> w_p ()
      | Tree tw -> (
        if f3 != ignore then Stack.push (C2nd (f3, tw)) stk2;
        Stack.push (C2tr tw.right) stk2;
        if f2 != ignore then Stack.push (C2nd (f2, tw)) stk2;
        Stack.push (C2tr tw.left) stk2;
        if f1 != ignore then Stack.push (C2nd (f1, tw)) stk2;
        w_p () ) )
    | C2nd (f, w) -> (f w.key; w_p ())
    | C2nil -> () in
  w_p ()

let t = ref Nil
let n = read_int ();;
for i = 1 to n do
  let s = read_line () in
  match (Scanf.sscanf s "%s" (fun x -> x)) with
  | "insert" ->
    t:= insert_s !t (Scanf.sscanf s "insert %d %d" (fun x y -> wood x y Nil Nil))
  | "print" -> (
    walk_print_s !t ignore (Printf.printf " %d") ignore;
    print_newline ();
    walk_print_s !t (Printf.printf " %d") ignore ignore;
    print_newline () )
  | "find" -> print_endline (find !t (Scanf.sscanf s "find %d" (fun x -> x)))
  | "delete" ->
    let kd = (Scanf.sscanf s "delete %d" (fun x -> x)) in
    t := delete_s !t kd
  | _ -> ()
done
