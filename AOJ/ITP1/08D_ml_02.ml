(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_8_D/review/2030023/ydash/OCaml *)
let () =
  let s = read_line () in
  let word = read_line () in
  let is_contanin =
    let len_s = String.length s in
    let len_w = String.length word in
    let ling = s ^ s in
    let rec iter i =
      if i=len_s then false
      else (if (String.sub ling i len_w) = word then true
            else iter (i+1))
    in iter 0
  in
  print_endline (if is_contanin then "Yes" else "No")
