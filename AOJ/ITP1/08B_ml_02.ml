(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_8_B/review/1867360/superluminalsloth/OCaml *)
let sum_of_digits s =
  let rec loop sum = function
    i when i = (String.length s) -> string_of_int sum
    | i -> loop (sum + (int_of_char s.[i]) - 48) (i+1)
  in loop 0 0;;
let rec read u =
  let str = read_line () in
  if str.[0] != '0' then begin
      sum_of_digits str |> print_endline;read u
    end;;
read();;
