#load "nums.cma"
open Big_int

let solve a b = add_big_int a b;;

let () =
  let x = Scanf.scanf "%s %s" (fun a b -> solve (big_int_of_string a) (big_int_of_string b)) in
  Printf.printf "%s\n" (Big_int.string_of_big_int x) ;;
