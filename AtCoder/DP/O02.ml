(*https://atcoder.jp/contests/dp/submissions/20810196*)
open Core_kernel
open Stdio
let memoize1 (size: int) (f_norec: (int -> 'a) -> int -> 'a): int -> 'a =
  let memo = Array.create ~len:size None in
  let rec g n =
    match memo.(n) with
      Some x  -> x
    | None ->
      let result = f_norec g n in
      memo.(n) <- Some result;
      result
  in
  g

let () =
  let n = Caml.read_int () in
  let d = Array.make_matrix ~dimx:n ~dimy:n false in
  for i = 0 to n - 1 do
    for j = 0 to n - 1 do
      d.(i).(j) <- Scanf.scanf "%d " (fun x -> if x = 1 then true else false)
    done
  done;
  let all = List.range 0 n in
  let f f_rec bset =
    if bset = 1 lsl n - 1 then 1
    else
      let i = Int.popcount bset in
      all
      |> List.filter ~f:(fun j -> bset land (1 lsl j) = 0 && d.(i).(j))
      |> List.map ~f:(fun j -> f_rec (bset lor (1 lsl j)))
      |> List.fold ~init:0 ~f:(fun x y -> (x + y) mod 1000_000_007)
  in
  let f_memo = memoize1 (1 lsl n) f in
  f_memo 0 |> printf "%d\n"
