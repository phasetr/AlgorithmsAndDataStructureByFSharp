(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_7_A/review/2428454/r6eve/OCaml *)
let nil = -1

type tree = { mutable parent : int; mutable child : int; mutable bro : int; mutable depth : int }

let make () = { parent = nil; child = nil; bro = nil; depth = nil }

let set_depth t n =
  let rec root i =
    if i = n then nil
    else if t.(i).parent = nil then i
    else root (i + 1) in
  let rec doit i d =
    t.(i).depth <- d;
    if t.(i).bro <> nil then doit t.(i).bro d;
    if t.(i).child <> nil then doit t.(i).child (d + 1) in
  doit (root 0) 0

let print_tree t =
  t |> Array.iteri (fun i _ ->
           print_string "node "; print_int i;
           print_string ": parent = "; print_int t.(i).parent;
           print_string ", depth = "; print_int t.(i).depth;
           print_string (if t.(i).parent = nil then ", root, [" else if t.(i).child = nil then ", leaf, [" else ", internal node, [");
           let c = ref t.(i).child in
           while !c <> nil do
             if !c <> t.(i).child then print_string ", ";
             print_int !c;
             c := t.(!c).bro;
           done;
           print_string "]\n")

let () =
  let n = Scanf.scanf "%d " (fun i -> i) in
  let t = Array.init n (fun _ -> make ()) in
  for _ = 0 to n - 1 do
    let (id, k) = Scanf.scanf "%d %d " (fun id k -> (id, k)) in
    let left_child = ref 0 in
    for i = 0 to k - 1 do
      let c = Scanf.scanf "%d " (fun i -> i) in
      t.(c).parent <- id;
      if i = 0 then t.(id).child <- c else t.(!left_child).bro <- c;
      left_child := c;
    done;
  done;
  set_depth t n;
  print_tree t
