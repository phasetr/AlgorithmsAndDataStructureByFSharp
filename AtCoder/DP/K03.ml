(*https://atcoder.jp/contests/dp/submissions/3948752*)
let () = Scanf.scanf "%d %d\n" @@ fun n k ->
  let as_ = Array.to_list @@ Array.init n @@ fun _ -> Scanf.scanf "%d " @@ fun a -> a in
  let dp = Array.make (k + 1) false in
  for i = 1 to k do
    dp.(i) <- not @@ List.for_all (fun a -> i - a < 0 || dp.(i - a)) as_
  done;
  print_endline @@
  if dp.(k) then "First" else "Second"
