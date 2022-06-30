let solve a b = if a<b then "a < b" else if a=b then "a == b" else "a > b";;
let a,b = Scanf.scanf "%d %d" (fun a b -> a,b);;
let () = Printf.printf "%s\n" (solve a b);;

solve 1 2 = "a < b";;
solve 4 3 = "a > b";;
solve 5 5 = "a == b";;
