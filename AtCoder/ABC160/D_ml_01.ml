(* https://atcoder.jp/contests/abc160/submissions/12813162 *)
let id x = x

let init n f =
  let rec g i ns = if i = 0 then 0 :: ns else g (i - 1) (i :: ns) in
  List.map f (g (n - 1) [])

let (n, x, y) = Scanf.scanf "%d %d %d" @@ fun n x y -> (n, x, y)

let f (i, j) =
  let rec min' m = function
    | [] -> m
    | x :: xs -> min' (min m x) xs
  in
  min' max_int [(abs (i - j)); (abs (i - y)) + 1 + (abs (x - j)); (abs (i - x)) + 1 + (abs (y - j))]

let () =
  let k = Array.make (n + 1) 0 in
  for i = 1 to n - 1 do
    for j = i + 1 to n do
      let d = f (i, j) in k.(d) <- k.(d) + 1
    done
  done;
  for i = 1 to n - 1 do
    Printf.printf "%d\n" k.(i)
  done
