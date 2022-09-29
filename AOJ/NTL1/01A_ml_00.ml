let solve n =
  let rec frec i x acc =
    if i*i > n then if x = 1 then acc else x :: acc
    else if x mod i = 0 then frec i (x / i) (i :: acc)
    else frec (i + 1) x acc in
  frec 2 n [] |> List.rev;;

let () =
  let n = read_int () in
  Printf.printf "%d:" n;
  solve n |> List.iter (fun e -> Printf.printf " %d" e);
  print_newline ()
