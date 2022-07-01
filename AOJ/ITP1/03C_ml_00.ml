let rec main ()= match Scanf.scanf "%d %d\n" (fun x y -> if x<y then (x,y) else (y,x)) with
  | (0,0) -> ()
  | (x,y) -> Printf.printf "%d %d\n" x y; main ();;
let () = main ();;
