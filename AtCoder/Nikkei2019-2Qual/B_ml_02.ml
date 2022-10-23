(* https://atcoder.jp/contests/nikkei2019-2-qual/submissions/8359204 *)
let m = 998244353
let ( +^ ) x y = (x + y) mod m
let ( *^ ) x y = (x * y) mod m

let rec power ( * ) e m n =
  if n <= 0 then e
  else power ( * ) (if n land 1 = 0 then e else m * e) (m * m) (n lsr 1)

let () = Scanf.scanf "%d\n" @@ fun n ->
  let ds = Array.init n @@ fun _ -> Scanf.scanf "%d " @@ fun d -> d in
  let dp = Array.make n 0 in
  let count = Array.make n 0 in
  Array.iter (fun d -> count.(d) <- 1 + count.(d)) ds;
  dp.(0) <- if ds.(0) = 0 then 1 else 0;
  for i = 1 to n - 1 do
    dp.(i) <- power ( *^ ) 1 count.(i - 1) count.(i) *^ dp.(i - 1)
  done;
  Printf.printf "%d\n" @@
  if
    Array.fold_left ( || ) false @@
    Array.init n @@ fun i -> i <> 0 && ds.(i) = 0
  then 0
  else dp.(Array.fold_left max min_int ds)
