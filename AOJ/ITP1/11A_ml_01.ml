(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_11_A/review/4033157/Wasedadaigaku/OCaml *)
let () =
  let a,b,c,d,e,f = Scanf.sscanf (read_line ()) "%d %d %d %d %d %d" (fun a b c d e f -> a,b,c,d,e,f) in
  let command = read_line () in
  let rec roll a b c d e f i' =
    if i' < String.length command then
      let i = i'+1 in
      match command.[i'] with
      | 'E' -> roll d b a f e c i
      | 'W' -> roll c b f a e d i
      | 'S' -> roll e a c d f b i
      | 'N' -> roll b f c d a e i
      | _ -> ()
    else (print_int a; print_char '\n')
  in
  roll a b c d e f 0
;;
