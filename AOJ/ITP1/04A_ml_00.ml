let solve a b = (a/b, a mod b, ((float_of_int a) /. (float_of_int b)));;
let a,b = Scanf.scanf "%d %d" (fun a b -> a,b);;
let () = (solve a b) |> fun (a,b,c) -> Printf.printf "%d %d %f\n" a b c;;

solve 3 2 = (1,1,1.5)
