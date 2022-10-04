#load "nums.cma"
open Big_int

let solve a_str b_str =
  let a = big_int_of_string a_str in
  let b = big_int_of_string b_str in
  mod_big_int a b;;
let () =
  let x = Scanf.scanf "%s %s" (fun a b -> solve a b) in
  Printf.printf "%s\n" (string_of_big_int x);;

let to_b = big_int_of_string;;
Printf.printf "%B\n" (eq_big_int (mod_big_int (to_b "5") (to_b "8")) (to_b "5"));;
Printf.printf "%B\n" (eq_big_int (mod_big_int (to_b "100") (to_b "25")) (to_b "0"));;

Printf.printf "%B\n" (eq_big_int (solve "5"   "8")  (to_b "5"));;
Printf.printf "%B\n" (eq_big_int (solve "100" "25") (to_b "0"));;
