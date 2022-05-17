(*https://atcoder.jp/contests/dp/submissions/28039199*)
open Core
open Printf
open Scanf
open Num

let id x = x

(* *)

let n = scanf "%d " id
let h = Array.init n ~f:(fun _ -> scanf "%d " id)

(* *)
let dp = Array.init (n + 1) ~f:(fun _ -> None)
let h i = if i <= 0 || n < i then None else Some h.(i - 1)

let rec next i j =
  let c = cost i in
  let hi = h i in
  let hj = h j in
  match c, hi, hj with
  | Some c, Some hi, Some hj -> Some (c + Int.abs (hi - hj))
  | _ -> None

and cost i =
  if i = 1
  then Some 0
  else if i <= 0 || n < i
  then None
  else (
    match dp.(i) with
    | Some x -> Some x
    | None ->
      let a = next (i - 1) i in
      let b = next (i - 2) i in
      let out =
        match a, b with
        | Some a, Some b -> Some (min a b)
        | a, None -> a
        | None, b -> b
      in
      dp.(i) <- out;
      out)
;;

let () = cost n |> Option.value ~default:(-1) |> printf "%d\n"
