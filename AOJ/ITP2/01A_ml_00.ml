#load "str.cma"
open Str

(* TLEした *)
let solve qs =
  let rec frec stk ps qs =
    match qs with
    | [] -> (List.rev stk, List.rev ps)
    | _ ->
       match List.hd qs with
       | [0;x] -> frec (x::stk) ps (List.tl qs)
       | [1;x] -> frec stk ((List.nth stk (List.length stk - x - 1))::ps) (List.tl qs)
       | _     -> frec (List.tl stk) ps (List.tl qs) in
  frec [] [] qs |> snd;;

let q = read_int() in
let qs = (Array.init q @@ fun _ -> read_line() |> Str.split (Str.regexp " ") |> List.map int_of_string) |> Array.to_list in
solve qs |> List.iter (Printf.printf "%d\n");;

(* 以下テスト用コード *)
let qs = [[0;1];[0;2];[0;3];[2];[0;4];[1;0];[1;1];[1;2]];;

let pushBack x xs = Array.append xs [|x|]
let randomAccess x xs = xs.(x)
let popBack xs = Array.sub xs 0 (Array.length xs - 1)

let () =
  pushBack 1 [|1;2|]; (* [|1;2;1|] *)
  pushBack 3 [|1;2|]; (* [|1;2;3|] *)
  randomAccess 0 [|1;2;3|]; (* 1 *)
  randomAccess 1 [|1;2;3|]; (* 2 *)
  randomAccess 2 [|1;2;3|]; (* 3 *)
  popBack [|1;2;3|]; (* [|1;2|] *)
  popBack [|1;2|]; (* [|1|] *)
  String.split_on_char ' ' "0 1" |> List.map int_of_string;
