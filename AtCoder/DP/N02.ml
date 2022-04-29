(*https://atcoder.jp/contests/dp/submissions/3949587*)
let () = Scanf.scanf "%d\n" @@ fun n ->
  let as_ = Array.init n @@ fun _ -> Scanf.scanf "%d " @@ fun a -> a in
  let acc = Array.make (n + 1) 0 in
  for i = 0 to n - 1 do
    acc.(i + 1) <- as_.(i) + acc.(i)
  done;
  let dp = Array.make_matrix n n 0 in
  for w = 1 to n - 1 do
    for l = 0 to n - w - 1 do
      dp.(l).(l + w) <- ( + ) (acc.(l + w + 1) - acc.(l)) @@
        Array.fold_left min max_int @@
        Array.init w @@ fun i -> dp.(l).(l + i) + dp.(l + i + 1).(l + w)
    done
  done;
  Printf.printf "%d\n" dp.(0).(n - 1)
