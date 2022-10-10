(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/DSL_1_A/review/1879822/karita/OCaml *)
let read_lines () =
  let rec iter xs =
    try read_line() :: xs |> iter
    with End_of_file -> xs
  in iter [] |> List.rev

let split_nums str =
  Str.split (Str.regexp " ") str
  |> List.map int_of_string

let read_ints () =
  read_line () |> split_nums |> Array.of_list


let init n = Array.init n (fun x -> x)

let rec find i a =
  if a.(i) = i then i
  else compress a.(i) a
and compress i a =
  a.(i) <- find i a;
  a.(i)

let same x y a =
  find x a = find y a

let void _ = ()

let unite x y a =
  let i = find x a
  and j = find y a in
  if i = j then ()
  else a.(i) <- j

let () =
  let first_line = read_ints () in
  let tree = init first_line.(0) in
  let answer com x y =
    match com with
    | 0 -> unite x y tree;
    | 1 ->
       Printf.printf "%d\n" (if same x y tree then 1 else 0);
    | _ -> raise Not_found in

  for i = 1 to first_line.(1) do
    let xs = read_ints () in
    answer xs.(0) xs.(1) xs.(2)
  done
