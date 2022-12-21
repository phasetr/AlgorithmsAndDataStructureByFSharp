(* https://atcoder.jp/contests/agc014/submissions/3054944 *)
let () =
  Scanf.scanf "%d %d" @@ fun n m ->
  let d = Array.make n 0 in
  for _ = 1 to m do
    Scanf.scanf " %d %d" @@ fun a b ->
      d.(a-1) <- 1 + d.(a-1);
      d.(b-1) <- 1 + d.(b-1);
  done;
  let m = Array.fold_left (fun s x -> s + x mod 2) 0 d in
  print_endline @@ if m = 0 then "YES" else "NO"
