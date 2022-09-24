(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_14_A/review/1970825/superluminalsloth/OCaml *)
let () =
  let s1 = read_line () and
      s2 = read_line () in
  let len1 = String.length s1 and
      len2 = String.length s2 in
  for i = 0 to len1 - len2 do
    if s1.[i] = s2.[0] then
      if String.sub s1 i len2 = s2 then
        Printf.printf "%d\n" i
  done
