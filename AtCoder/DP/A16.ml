(* https://atcoder.jp/contests/dp/submissions/19481065 *)
open Core;;
open Stdio;;

let memoize1 (size: int) (f_norec: (int -> 'a) -> int -> 'a): int -> 'a =
  let memo = Array.create ~len:size Int.min_value in
  let rec g n =
    match memo.(n) with
      x when x <> Int.min_value  -> x
    | _ ->
      let result = f_norec g n in
      memo.(n) <- result;
      result
  in g;;

let () =
  let n = Scanf.sscanf (Caml.read_line ()) "%d" (fun x -> x) in
  let s = Caml.read_line () in
  let h = String.split ~on:' ' s |> List.map ~f:(Int.of_string) |> Array.of_list in
  let solve = memoize1 n (fun f n ->
      match n with
        0 -> 0
      | 1 -> Int.abs (h.(1) - h.(0))
      | n ->
        Int.min
          (f (n - 1) + Int.abs (h.(n) - h.(n - 1)))
          (f (n - 2) + Int.abs (h.(n) - h.(n - 2))))
  in
  solve (n - 1)
  |> printf "%d\n";;
