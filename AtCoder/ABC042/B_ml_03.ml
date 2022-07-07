(* https://atcoder.jp/contests/abc042/submissions/4377347 *)
let () =
  let n = Scanf.scanf " %d %d\n" (fun n _ -> n) in
  List.init n (fun _ -> Scanf.scanf "%s\n" (fun x -> x))
  |> List.sort compare
  |> List.fold_left (fun x y -> x ^ y) ""
  |> print_endline
