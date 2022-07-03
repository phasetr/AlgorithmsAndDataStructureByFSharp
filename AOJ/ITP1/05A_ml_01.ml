(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_5_A/review/2782062/tetrose/OCaml *)
let rec draw h w =
  let rec draw' w =
    match w with
    | 0 -> print_string "\n"
    | _ -> print_string "#";draw' (w-1)
  in
  match h with
  | 0 -> print_string "\n"
  | _ -> draw' w;draw (h-1) w;;

let rec loop () =
  Scanf.sscanf(read_line()) "%d %d" (fun x y -> if x = 0 && y = 0 then () else (draw x y;loop()));;

loop();;
