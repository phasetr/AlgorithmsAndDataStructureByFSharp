(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_2_D/review/2004848/superluminalsloth/OCaml *)
let print_list l = List.map string_of_int l |> String.concat " " |> print_endline;;

let insertion_sort a n g count=
  let ct = (ref count) in
  for i = g to n-1 do
    let v = a.(i) in
    let rec loop j =
      if j < 0 || a.(j) <= v then (j+g)
      else
        begin
          a.(j+g) <- a.(j);incr ct;loop (j-g)
        end
    in a.(loop (i-g)) <-v;
  done;
  !ct;;

let () =
  let n = read_int () in
  let n' = float_of_int n in
  let rec gen g b =
    let b2 = b *. 2.25 +. 1. in
    if b2 > n' then g
    else gen ((int_of_float (ceil b2))::g) b2
  in
  let a = Array.init n (fun x -> read_int ()) and
      g = gen [] 0. in
  let m = List.length g in
  let rec loop ct = function
      [] -> print_int m;print_newline ();
            print_list g;
            print_int ct;print_newline ();
            Array.iter (fun x -> Printf.printf "%d\n" x) a
    | h::t -> loop (insertion_sort a n h ct) t
  in loop 0 g;;
