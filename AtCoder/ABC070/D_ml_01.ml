(* https://atcoder.jp/contests/abc070/submissions/9666914 *)
let n = read_int ()
let g, ds = Array.(make n [], make n 0)
let rec f v p d =
  ds.(v) <- d;
  List.iter (fun (u, c) -> if u <> p then f u v (d + c)) g.(v)
let _ =
  Scanf.(for _ = 1 to n - 1 do
           scanf " %d %d %d" @@
             fun a b c ->
             g.(a - 1) <- (b - 1, c) :: g.(a - 1);
             g.(b - 1) <- (a - 1, c) :: g.(b - 1)
         done;
         scanf " %d %d" @@
           fun q k -> f (k - 1) ~-1 0;
                      for _ = 1 to q do
                        scanf " %d %d" @@ fun x y -> Printf.printf "%d\n" @@ ds.(x - 1) + ds.(y - 1)
                      done)
