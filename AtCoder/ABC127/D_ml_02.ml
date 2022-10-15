(* https://atcoder.jp/contests/abc127/submissions/5628122 *)
(* O(N log N (N = max n m)) *)
Scanf.scanf "%d %d" @@ fun n m ->
  let cards = Array.init (n + m) @@ fun i ->
    if i < n then Scanf.scanf " %d" @@ fun a -> 1, a
    else Scanf.scanf " %d %d" @@ fun b c -> b, c in
  let cmp (b, c) (b1, c1) = c1 - c in
  Array.sort cmp cards;
  let rec loop ans i rest =
    if rest <= 0 then Printf.printf "%d\n" ans
    else
      let b, c = cards.(i) in
      let m = min b rest in
      loop (ans + m * c) (i + 1) (rest - m) in
  loop 0 0 n
