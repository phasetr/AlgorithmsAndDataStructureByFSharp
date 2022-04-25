(*https://atcoder.jp/contests/dp/submissions/3944724*)
let (+) a b = (a + b) mod 1000000007
let () =
  Scanf.scanf "%d %d" @@ fun h w ->
  let s = Array.init h (fun _ -> Scanf.scanf " %s" (fun x -> x)) in
  let dp = Array.init h (fun _ -> Array.make w 0) in
  dp.(0).(0) <- 1;
  for i = 0 to h-1 do
    for j = 0 to w-1 do
      if i > 0 && s.(i-1).[j] = '.' then dp.(i).(j) <- dp.(i).(j) + dp.(i-1).(j);
      if j > 0 && s.(i).[j-1] = '.' then dp.(i).(j) <- dp.(i).(j) + dp.(i).(j-1)
    done;
  done;
  Printf.printf "%d\n" dp.(h-1).(w-1)
