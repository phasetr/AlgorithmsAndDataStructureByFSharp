(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_10_C/review/1867788/superluminalsloth/OCaml *)
let split = Str.split (Str.regexp_string " ");;

let rec read () =
  let n = read_float () in
  if n > 0. then begin
      let l = read_line () |> split |> List.map float_of_string in
      let avg = (List.fold_left (+.) 0. l)/.n in
      (List.fold_left (fun x y -> x +. (y-.avg)**2.) 0. l)/.n
      |> sqrt |> Printf.printf "%.8f\n";read ()
    end;;

let () = read ();;
