(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_6_D/review/2982532/napo/OCaml *)
let () =
  let (n, m) = Scanf.sscanf(read_line()) "%d %d" (fun x y -> (x, y)) in
  let rec f xss i =
    if i = n then List.rev xss
    else (
      let ys = Str.split (Str.regexp " ") (read_line ()) |> List.map int_of_string in
      f (ys :: xss) (i + 1)
    ) in
  let rec g xs i =
    if i = m then List.rev xs
    else g ((read_line () |> int_of_string) :: xs) (i + 1) in
  let nss = f [] 0 in
  let ms  = g [] 0 in
  List.map (fun ns -> List.map2 ( * ) ns ms |> List.fold_left (+) 0) nss
  |> List.iter (Printf.printf "%d\n");;
