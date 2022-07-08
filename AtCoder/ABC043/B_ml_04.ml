(* https://atcoder.jp/contests/abc043/submissions/2139279 *)
let arr_of_str s = Array.init (String.length s) (fun i -> s.[i]);;
let f stk v =
  if v = 'B' then match stk with [] -> [] | (s::stk') -> stk'
  else (v::stk);;
let () =
  Scanf.scanf "%s" arr_of_str
  |> Array.fold_left f []
  |> List.fold_left (fun s x -> x :: s) []
  |> List.iter (Printf.printf "%c");
  print_newline ();;
