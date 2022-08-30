(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_6_B/review/1958316/superluminalsloth/OCaml *)
let swap a i j =
  let temp = a.(i) in
  a.(i) <- a.(j);
  a.(j) <- temp

let partition a p r =
  let x = a.(r) and
      i = ref (p-1) in
  for j = p to r-1 do
    if a.(j) <= x then
      begin
        i := !i + 1;
        swap a (!i) j;
      end;
  done;
  swap a (!i+1) r;
  !i+1

let print a p =
  for i = 0 to ((Array.length a)-1) do
    if i = p then
      Printf.printf "[%d]" a.(i)
    else
      Printf.printf "%d" a.(i);
    if i != ((Array.length a)-1) then
      Printf.printf " "
    else
      Printf.printf "\n"
  done

let () =
  let n = read_int () and
      a = read_line ()
          |> Str.split (Str.regexp " ")
          |> List.map int_of_string
          |> Array.of_list
  in
  let p = partition a 0 (n-1) in
  print a p
