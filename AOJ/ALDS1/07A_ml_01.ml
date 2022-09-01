(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_7_A/review/2433122/rabbisland/OCaml *)
open Printf
open Str

type node = {p : int option; cs : int list}
let read_list f = split (regexp " +") (read_line ()) |> List.map f
let string_of_list ls = let s = List.map string_of_int ls |> String.concat ", " in "[" ^ s ^ "]"

let int_of_parent n = match n.p with
  | None -> (-1)
  | Some x -> x

let type_of_node = function
  | {p = None} -> "root"
  | {cs = []} -> "leaf"
  | _ -> "internal node"

let length_of_node tr n =
  let rec iter d = function
    | {p = Some x} -> iter (d+1) tr.(x)
    | _ -> d
  in iter 0 n

let () =
  let n = read_int () in
  let tree = Array.make n {p = None; cs = []} in
  let rec read n =
    if n = 0 then ()
    else begin
        begin
          match read_list int_of_string with
            id::_::rs -> begin
              tree.(id) <- begin let n = tree.(id) in {n with cs = rs} end;
              List.iter (fun x -> let n = tree.(x) in tree.(x) <- {n with p = Some id}) rs
            end
          | _ -> failwith "read"
        end;
        read (n-1)
      end
  in
  read n;
  Array.iteri (fun i x -> let pi = int_of_parent x in
                          let sl = string_of_list x.cs in
                          let tn = type_of_node x in
                          let ln = length_of_node tree x in
                          printf "node %d: parent = %d, depth = %d, %s, %s\n" i pi ln tn sl) tree
