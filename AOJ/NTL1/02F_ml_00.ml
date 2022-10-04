#load "nums.cma"
open Big_int

let solve a_str b_str =
  let a = big_int_of_string a_str in
  let b = big_int_of_string b_str in
  mult_big_int a b;;

let () =
  let x = Scanf.scanf "%s %s" (fun a b -> solve a b) in
  Printf.printf "%s\n" @@ string_of_big_int x;;

Printf.printf "%B\n" (eq_big_int (solve "5" "8") (to_b "40"));;
Printf.printf "%B\n" (eq_big_int (solve "100" "25") (to_b "2500"));;
Printf.printf "%B\n" (eq_big_int (solve "-1" "0") (to_b "0"));;
Printf.printf "%B\n" (eq_big_int (solve "12" "-3") (to_b "-36"));;
