(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_11_D/review/2440144/r6eve/OCaml *)
let split_on_char sep s =
  let open String in
  let r = ref [] in
  let j = ref (length s) in
  for i = length s - 1 downto 0 do
    if get s i = sep then begin
      r := sub s (i + 1) (!j - i - 1) :: !r;
      j := i
    end
  done;
  sub s 0 !j :: !r

let read_ints () = read_line () |> split_on_char ' ' |>  List.map int_of_string

let dfs vs n =
  let d = Array.make n (-1) in
  let rec doit i j =
    d.(i) <- j;
    List.iter (fun v -> if d.(v) = (-1) then doit v j) vs.(i) in
  Array.iteri (fun i e -> if e = (-1) then doit i i) d;
  d

let solve n m =
  let g = Array.make n [] in
  for _ = 0 to m - 1 do
    match read_ints () with
    | [s; t] ->
      g.(s) <- t :: g.(s);
      g.(t) <- s :: g.(t);
    | _ -> assert false
  done;
  let v = dfs g n in
  let q = read_int () in
  for _ = 0 to q - 1 do
    match read_ints () with
    | [s; t] -> Printf.printf (if v.(s) = v.(t) then "yes\n" else "no\n")
    | _ -> assert false
  done

let () =
  match read_ints () with
  | [n;m] -> solve n m
  | _ -> assert false
