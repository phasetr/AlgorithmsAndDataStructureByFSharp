let rec solve a b c n acc =
  if b<n then acc
  else solve a b c (n+1) (if (c mod n == 0) then (acc+1) else acc)
;;
let () =
  let (a,b,c) = Scanf.scanf "%d %d %d\n" (fun a b c -> a,b,c) in
  Printf.printf "%d\n" @@ solve a b c a 0;;

solve 5 14 80 5 0 == 3
