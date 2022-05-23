(*https://atcoder.jp/contests/dp/submissions/28071011*)
open Core
open Printf
open Scanf
open Num

let id x = x
let n = scanf "%d " id
let pi = Array.init n ~f:(fun _ -> scanf "%f " id)
let pi i = pi.(i - 1)
let dp_tbl = Array.init (n + 1) ~f:(fun _ -> Array.init (n + 1) ~f:(fun _ -> None))

let rec calc i f =
  assert (0 <= i && i <= n && 0 <= f && f <= n);
  match dp_tbl.(i).(f) with
  | Some x -> x
  | None ->
    let x =
      if i = 0 && f = 0
      then 1.
      else if f > i
      then 0.
      else (
        let face =
          try calc (i - 1) (f - 1) *. pi i with
          | _ -> 0.0
        in
        let back =
          try calc (i - 1) f *. (1. -. pi i) with
          | _ -> 0.0
        in
        face +. back)
    in
    dp_tbl.(i).(f) <- Some x;
    x
;;

let () =
  Array.init (n + 1) ~f:(fun f -> if f > n - f then calc n f else 0.)
  |> Array.fold ~f:( +. ) ~init:0.0
  |> Float.to_string
  |> print_endline
;;
