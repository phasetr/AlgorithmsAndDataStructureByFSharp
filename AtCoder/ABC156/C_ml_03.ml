(* https://atcoder.jp/contests/abc156/submissions/10278772 *)
let () = Scanf.scanf "%d\n" @@ fun n ->
  let xs = Array.init n @@ fun _ -> Scanf.scanf "%d " @@ fun x -> x in
  Printf.printf "%d\n" @@
  Array.fold_left min max_int @@
  Array.init 101 @@ fun x ->
    Array.fold_left ( + ) 0 @@
    Array.init n @@ fun i -> (xs.(i)-x)*(xs.(i)-x)
