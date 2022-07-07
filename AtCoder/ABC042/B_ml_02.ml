(* https://atcoder.jp/contests/abc042/submissions/7672504 *)
let n, l = Scanf.scanf " %d %d" @@ fun a b -> a, b
let ss = Array.init n @@ fun _ -> Scanf.scanf " %s" @@ fun s -> s
let _ = Array.(sort compare ss; to_list ss |> String.concat "" |> print_endline)
