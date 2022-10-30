(* https://atcoder.jp/contests/abc051/submissions/7793127 *)
let dx, dy = Scanf.scanf " %d %d %d %d" @@ fun a b c d -> c - a, d - b
let f n c = print_string @@ String.make n c
let _ = f dy 'U'; f dx 'R'; f dy 'D'; f dx 'L';
  f 1 'L'; f (dy + 1) 'U'; f (dx + 1) 'R'; f 1 'D'; f 1 'R'; f (dy + 1) 'D'; f (dx + 1) 'L'; f 1 'U'
