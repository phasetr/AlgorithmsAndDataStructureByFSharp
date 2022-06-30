let solve a b c = if a<b && b<c then "Yes" else "No";;
let a,b,c = Scanf.scanf "%d %d %d" (fun a b c -> a,b,c);;
let () = Printf.printf "%s\n" (solve a b c);;

solve 1 3 8 = "Yes";;
solve 3 8 1 = "No";;
