(*https://atcoder.jp/contests/dp/submissions/3945070*)
let rec seq a b = if a > b then [] else a :: seq (a+1) b
let () =
  Scanf.scanf "%d" @@ fun n ->
  let p = Array.init n (fun _ -> Scanf.scanf " %f" ((+.) 0.)) in
  let dp = Array.init (n+1) (fun _ -> Array.make (n+1) 0.) in
  dp.(0).(0) <- 1.0;
  for x = 1 to n do
    for y = 0 to x do
      dp.(x).(y) <- dp.(x).(y) +. dp.(x-1).(y) *. (1. -. p.(x-1));
      if y > 0 then dp.(x).(y) <- dp.(x).(y) +. dp.(x-1).(y-1) *. p.(x-1);
    done;
  done;
  seq (n/2+1) n |> List.fold_left (fun s i -> s +. dp.(n).(i)) 0.0
  |> Printf.printf "%.15f\n"
