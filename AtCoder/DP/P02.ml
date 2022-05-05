(*https://atcoder.jp/contests/dp/submissions/3950015*)
let m = 1000000007
let ( +^ ) x y = (x + y) mod m
let ( *^ ) x y = (x * y) mod m

let () = Scanf.scanf "%d\n" @@ fun n ->
  let es = Array.make n [] in
  for i = 1 to n - 1 do
    Scanf.scanf "%d %d\n" @@ fun x y ->
      es.(x - 1) <- y - 1 :: es.(x - 1);
      es.(y - 1) <- x - 1 :: es.(y - 1)
  done;
  let visited = Array.make n false in
  let rec visit v =
    if visited.(v) then (0, 1)
    else begin
      visited.(v) <- true;
      List.fold_left (fun (b, w) u ->
        let (b', w') = visit u in
        (b *^ w', w *^ (b' +^ w'))) (1, 1) es.(v)
    end in
  let (b, w) = visit 0 in
  Printf.printf "%d\n" @@ b +^ w
