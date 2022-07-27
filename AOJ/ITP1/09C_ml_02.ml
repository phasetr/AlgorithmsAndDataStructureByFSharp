(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_9_C/review/2031936/ydash/OCaml *)
let () =
  let rec game a b = function
    | 0 -> Printf.printf "%d %d\n" a b
    | i ->
       let x,y = Scanf.scanf "%s %s\n"
                   (fun x y -> if x>y then 3,0 else if x<y then 0,3 else 1,1) in
       game (a+x) (b+y) (i-1)
  in
  let times = read_int () in
  game 0 0 times
