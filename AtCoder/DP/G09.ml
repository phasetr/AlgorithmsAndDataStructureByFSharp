(*https://atcoder.jp/contests/dp/submissions/3944462*)
let rec range a b = if a >= b then [] else a :: range (a+1) b
let () =
  Scanf.scanf "%d %d" @@ fun n m ->
  let g = Array.init n (fun _ -> []) in
  for _ = 1 to m do
    Scanf.scanf " %d %d" @@ fun x y -> g.(x-1) <- y-1 :: g.(x-1)
  done;
  let dp = Array.make n (-1) in
  let rec f v =
    if dp.(v) >= 0 then dp.(v)
    else begin
      let l = 1 + List.fold_left (fun s w -> max s (f w)) (-1) g.(v) in
      dp.(v) <- l;  l
    end
  in
  range 0 n |> List.fold_left (fun s i -> max s (f i)) 0
  |> Printf.printf "%d\n"
