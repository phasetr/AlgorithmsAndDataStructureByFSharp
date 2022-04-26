(*https://atcoder.jp/contests/dp/submissions/3950676*)
let () = Scanf.scanf "%d\n" @@ fun n ->
  let ps = Array.init n @@ fun _ -> Scanf.scanf "%f " @@ fun p -> p in
  let dp = Array.make_matrix (n + 1) (2 * n + 3) 0. in
  dp.(0).(n + 1) <- 1.;
  for i = 0 to n - 1 do
    for j = n - i to n + 2 + i do
      dp.(i + 1).(j) <- ps.(i) *. dp.(i).(j - 1) +. (1. -. ps.(i)) *. dp.(i).(j + 1)
    done
  done;
  Printf.printf "%.12f" @@ Array.fold_left ( +. ) 0. @@ Array.init (n + 1) @@ fun i -> dp.(n).(i + n + 1)

