(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_3_C/review/1829547/superluminalsloth/OCaml *)
let rec read ()=
  let t = Scanf.scanf "%d %d\n" (fun x y-> if x<y then (x,y) else (y,x)) in
  match t with
    (0,0) -> ()
  | (x,y) -> Printf.printf "%d %d\n" x y;read ();;
let () = read ();;
