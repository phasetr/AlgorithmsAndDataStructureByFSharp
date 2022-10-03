#load "nums.cma"
open Big_int

let solve a b = div_big_int a b;;

let () =
  let x = Scanf.scanf "%s %s" (fun a b -> solve (big_int_of_string a) (big_int_of_string b)) in
  Printf.printf "%s\n" (Big_int.string_of_big_int x);;

let to_b = big_int_of_string

Printf.printf "%B\n" (eq_big_int (solve (to_b "5") (to_b "8")) (to_b "0"));;
Printf.printf "%B\n" (eq_big_int (solve (to_b "100") (to_b "25")) (to_b "4"));;
Printf.printf "%B\n" (eq_big_int (solve (to_b "-1") (to_b "3")) (to_b "0"));; (* これが通らない *)
Printf.printf "%B\n" (eq_big_int (solve (to_b "12") (to_b "-3")) (to_b "-4"));;
