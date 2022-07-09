(* https://atcoder.jp/contests/abc044/submissions/15336681 *)
Scanf.scanf "%s" (fun w ->
    let h = Array.make 26 0 in
    String.iter (fun v -> let q = int_of_char v - 97 in h.(q) <- h.(q) + 1) w;
    print_endline @@ if Array.fold_left (lor) 0 h mod 2 = 0 then "Yes" else "No")
