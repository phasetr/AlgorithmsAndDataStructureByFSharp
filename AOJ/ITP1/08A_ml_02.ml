(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_8_A/review/4467828/tt99kuze/OCaml *)
let switch c =
  let uc = Char.uppercase_ascii c in
  let lc = Char.lowercase_ascii c in
  if uc = c && lc <> c then lc
  else if uc <> c && lc = c then uc
  else c ;;
let () =
  let s = read_line() in
  for i = 0 to (String.length s) - 1 do
    Printf.printf "%c" (switch s.[i])
  done;
  print_newline();;
