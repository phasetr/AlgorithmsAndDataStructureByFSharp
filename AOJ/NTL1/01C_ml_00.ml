(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_1_C/review/2461508/r6eve/OCaml *)
let solve xs =
  let gcd m n =
    let rec frec x y = if y <= 0 then x else frec y (x mod y) in
    frec (max m n) (min m n) in
  let lcm m n = m*n / (gcd m n) in
  List.fold_left lcm (List.hd xs) (List.tl xs)

let () =
  let _ = read_int () in
  read_line () |> Str.split (Str.regexp " ") |> List.map int_of_string
  |> solve |> Printf.printf "%d\n"
