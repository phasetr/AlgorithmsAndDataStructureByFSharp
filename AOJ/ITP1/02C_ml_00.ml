let solve a b c =
  let xa = [|a;b;c|] in
  Array.sort compare xa;
  Printf.sprintf "%d %d %d" xa.(0) xa.(1) xa.(2);;
let a,b,c = Scanf.scanf "%d %d %d" (fun a b c -> a,b,c);;
let () = Printf.printf "%s\n" (solve a b c);;

solve 3 8 1 = "1 3 8";;
