(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_8_B/review/2441550/rabbisland/OCaml *)
open Str

type btree = Node of node | Nil and
node = {k : int; l : btree; r : btree}

let preorder f tr =
  let rec iter = function
      Nil -> ()
    | Node n -> f n.k; iter n.l; iter n.r
  in iter tr; print_newline ()

let inorder f tr =
  let rec iter = function
      Nil -> ()
    | Node n -> iter n.l; f n.k; iter n.r
  in iter tr; print_newline ()

let insert k tr =
  let rec iter = function
      Nil -> Node {k = k; l = Nil; r = Nil}
    | Node n -> if n.k = k then Node n
                else if n.k < k then Node {n with r = iter n.r}
                else Node {n with l = iter n.l}
  in iter tr

let find k tr =
  let rec iter = function
      Nil -> "no"
    | Node n -> if n.k = k then "yes"
                else if n.k < k then iter n.r
                else iter n.l
  in iter tr

let read_list () =
  split (regexp " +") (read_line ())

let () =
  let n = read_int () in
  let rec read tr x =
    if x = 0 then ()
    else match read_list () with
           "print" :: _ -> begin
             inorder (fun i -> print_string @@ " " ^ (string_of_int i)) tr;
             preorder (fun i -> print_string @@ " " ^ (string_of_int i)) tr;
             read tr (x-1)
           end
         | "insert" :: ns :: _ -> read (insert (int_of_string ns) tr) (x-1)
         | "find" :: ns :: _ -> begin
             find (int_of_string ns) tr |> print_endline;
             read tr (x-1)
           end
         | _ -> failwith "read"
  in
  read Nil n
