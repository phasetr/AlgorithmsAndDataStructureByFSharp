(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_7_B/review/2431763/r6eve/OCaml *)
let nil = -1

type node = {
    mutable parent : int;
    mutable left : int;
    mutable right : int;
    mutable depth : int;
    mutable height : int;
  }

let make () = { parent = nil; left = nil; right = nil; depth = nil; height = nil }

let search_root t n =
  let rec doit i =
    if i = n then nil
    else if t.(i).parent = nil then i
    else doit (i + 1) in
  doit 0

let set_depth t root =
  let rec doit i d =
    if i = nil then ()
    else begin
        t.(i).depth <- d;
        doit t.(i).left (d + 1);
        doit t.(i).right (d + 1)
      end in
  doit root 0

let set_height t root =
  let rec doit i =
    t.(i).height <- max (if t.(i).left = nil then 0 else doit t.(i).left + 1)
                      (if t.(i).right = nil then 0 else doit t.(i).right + 1);
    t.(i).height in
  doit root |> ignore

let print t =
  let sibling i =
    if t.(i).parent = nil then nil
    else
      let (l, r) = (t.(t.(i).parent).left, t.(t.(i).parent).right) in
      if l <> nil && l <> i then l
      else if r <> nil && r <> i then r
      else nil in
  let degree i = (if t.(i).left = nil then 0 else 1) + (if t.(i).right = nil then 0 else 1) in
  t |> Array.iteri (fun i _ ->
           "node " ^ string_of_int i
           ^ ": parent = " ^ string_of_int t.(i).parent
           ^ ", sibling = " ^ string_of_int (sibling i)
           ^ ", degree = " ^ string_of_int (degree i)
           ^ ", depth = " ^ string_of_int t.(i).depth
           ^ ", height = " ^ string_of_int t.(i).height
           ^ (if t.(i).parent = nil then ", root"
              else if t.(i).left = nil && t.(i).right = nil then ", leaf"
              else ", internal node")
           ^ "\n"
           |> print_string)

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
  set_depth t root;
  set_height t root;
  print t
