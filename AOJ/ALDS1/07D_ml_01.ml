(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_7_D/review/2440192/rabbisland/OCaml *)
open Str

module L =
  struct
    include List

    let rec take n = function
        [] -> []
      | h :: t when n > 0 -> h :: take (n - 1) t
      | _ -> []

    let rec drop n = function
        [] -> []
      | h :: t when n > 0 -> drop (n - 1) t
      | l -> l

    let rec break f = function
        [] -> ([],[])
      | h :: t as l when f h -> ([],l)
      | h :: t -> let (xs, ys) = break f t in (h::xs, ys)
  end

let read_list f =
  split (regexp " +") (read_line ()) |> List.map f

let rec postorder pl il rl =
  match pl with
    [] -> rl
  | x :: xs -> let (lil, ril) = L.break (fun a -> a = x) il in
               let lpl = L.take (L.length lil) xs in
               let rpl = L.drop (L.length lil) xs in
               let rl' = postorder rpl (L.tl ril) (x::rl) in
               postorder lpl lil rl'
let () =
  let _ = read_line () in
  let pl = read_list int_of_string in
  let il = read_list int_of_string in
  postorder pl il [] |> L.map string_of_int |> String.concat " " |> print_endline
