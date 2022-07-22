(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_8_C/review/1853229/superluminalsloth/OCaml *)
let dict = Array.init 26 (fun n -> ((Char.chr (97+n)),0));;

let increment c =
  let code = (Char.code c) in
  if code >= 97 && code <= 122 then
    let i = (-) (Char.code c) 97 in
    let ( _, n) = dict.(i) in dict.(i) <- (c, (n+1))
  else ();;

let rec read u =
  try let line = read_line () in
      String.iter (fun ch -> Char.lowercase_ascii ch |> increment) line;
      read u
  with
    End_of_file ->
    Array.iter (fun (a,b) -> Printf.printf "%c : %d\n" a b) dict;;

let () = read ();;
