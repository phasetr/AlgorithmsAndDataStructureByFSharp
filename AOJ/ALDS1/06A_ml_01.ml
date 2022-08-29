(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_6_A/review/2428662/rabbisland/OCaml *)
open Str
open Scanf

let id x = x

let read_array n =
  Array.init n (fun i -> if i = 0 then scanf "%d" id else scanf " %d" id)

let print_array a =
  Array.iteri (fun i x -> if i > 0 then print_string " " else (); print_int x) a; print_newline ()

let counting_sort a b k =
  let c = Array.make (k+1) 0 in
  let rec idx i =
    if i > k then () else
      begin c.(i) <- c.(i) + c.(i-1); idx (i+1) end in
  Array.iter (fun x -> c.(x) <- c.(x) + 1) a;
  idx 1;
  Array.iter (fun x -> let i = c.(x) - 1 in b.(i) <- x; c.(x) <- i) a

let () =
  let n = read_int () in
  let ar = read_array n in
  let res = Array.make n 0 in
  counting_sort ar res 10000;
  print_array res
