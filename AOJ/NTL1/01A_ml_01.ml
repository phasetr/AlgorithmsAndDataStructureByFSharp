(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_1_A/review/2461478/r6eve/OCaml *)
let () =
  let n = read_int () in
  Printf.printf "%d:" n;
  let rec doit i x acc =
    if i*i > n then
      if x = 1 then acc
      else x :: acc
    else if x mod i = 0 then doit i (x / i) (i :: acc)
    else doit (i + 1) x acc in
  doit 2 n [] |> List.rev |> List.iter (fun e -> Printf.printf " %d" e);
  print_newline ()
