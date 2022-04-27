(*https://atcoder.jp/contests/dp/submissions/3946959*)
let () =
  Scanf.scanf "%d %d" @@ fun n k ->
  let a = Array.init n (fun _ -> Scanf.scanf " %d" ((+) 0)) in
  let dp = Array.make (k+1) 0 in
  for i = 1 to k do
    dp.(i) <-
      1 - Array.fold_left (fun s w -> if w <= i then min s dp.(i-w) else s) 1 a
  done;
  print_endline [|"Second"; "First"|].(dp.(k))
