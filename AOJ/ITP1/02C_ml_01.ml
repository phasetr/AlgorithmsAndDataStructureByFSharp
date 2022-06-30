let solve xa =
  Array.sort compare xa;
  Printf.sprintf "%d %d %d" xa.(0) xa.(1) xa.(2);;
let xa = Scanf.scanf "%d %d %d" (fun a b c -> [|a;b;c|]);;
let () = solve xa |> Printf.printf "%s\n";;

solve [|3;8;1|] = "1 3 8";;
