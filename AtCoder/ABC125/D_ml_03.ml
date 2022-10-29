(* https://atcoder.jp/contests/abc125/submissions/5153162 *)
let () = Scanf.scanf "%d\n" @@ fun n ->
  let as_ = Array.init n @@ fun _ -> Scanf.scanf "%d " @@ fun a -> a in
  let dp = Array.make_matrix (n + 1) 2 0 in
  dp.(0).(0) <- 0;
  dp.(0).(1) <- -12345678901234;
  for i = 0 to n - 1 do
    dp.(i + 1).(0) <- max (dp.(i).(0) + as_.(i)) (dp.(i).(1) - as_.(i));
    dp.(i + 1).(1) <- max (dp.(i).(0) - as_.(i)) (dp.(i).(1) + as_.(i))
  done;
  Printf.printf "%d\n" dp.(n).(0)
