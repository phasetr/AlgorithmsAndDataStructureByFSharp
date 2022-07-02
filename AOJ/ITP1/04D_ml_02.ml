(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_4_D/review/2962229/napo/OCaml *)
let _ = read_line() in
let xs = read_line() |> Str.split (Str.regexp " ") |> List.map int_of_string in
let rec f (mi, ma, sum) x = ((min mi x), (max ma x), (x + sum)) in
let (min', max', sum') = List.fold_left f (1000000, (-1000000), 0) xs in
Printf.printf "%d %d %d\n" min' max' sum';
