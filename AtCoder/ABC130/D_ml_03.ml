(* https://atcoder.jp/contests/abc130/submissions/7409202 *)
let rec lower_bound l r p =
  if r <= 1 + l
  then r
  else let m = (l + r) / 2 in
       if p m
       then lower_bound l m p
       else lower_bound m r p

let () = Scanf.scanf "%d %d\n" @@ fun n k ->
  let as_ = Array.init n @@ fun _ -> Scanf.scanf "%d " @@ fun a -> a in
  let acc = Array.make (n + 2) 0 in
  for i = 0 to n - 1 do
    acc.(i + 1) <- acc.(i) + as_.(i)
  done;
  acc.(n + 1) <- max_int;
  Printf.printf "%d\n" @@
  Array.fold_left ( + ) 0 @@
  Array.init n @@ fun i ->
    ( - ) (n + 1) @@
    lower_bound (-1) (n + 1) @@ fun j ->
      k <= acc.(j) - acc.(i)
