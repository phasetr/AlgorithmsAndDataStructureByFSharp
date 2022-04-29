(*https://atcoder.jp/contests/dp/submissions/3948307*)
let () =
  Scanf.scanf "%d" @@ fun n ->
  let a = Array.init n (fun _ -> Scanf.scanf " %d" ((+) 0)) in
  let sa = Array.make (n+1) 0 in
  for i = 1 to n do sa.(i) <- sa.(i-1) + a.(i-1) done;

  let dp = Array.init (n+1) (fun _ -> Array.make (n+1) max_int) in
  for i = 0 to n-1 do dp.(i).(i+1) <- 0 done;
  for w = 2 to n do
    for i = 0 to n-w do
      for j = i+1 to i+w-1 do
        dp.(i).(i+w) <- min dp.(i).(i+w) (dp.(i).(j) + dp.(j).(i+w) + sa.(i+w) - sa.(i))
      done;
    done;
  done;
  Printf.printf "%d\n" dp.(0).(n)
