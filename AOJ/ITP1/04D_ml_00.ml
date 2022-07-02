let solve xs =
  List.fold_left (fun (accx, accy, accz) x -> (min accx x, max accy x, accz+x))
    (max_int, min_int, 0) xs;;
let () =
  let _ = read_int () in
  read_line () |> Str.split (Str.regexp " ") |> List.map int_of_string |> solve
  |> fun (a,b,c) -> Printf.printf "%d %d %d\n" a b c;;

solve [10;1;5;4;17] = (1,17,37);;
