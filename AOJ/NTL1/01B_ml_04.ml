(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_1_B/review/1815876/lazyhawk/OCaml *)
let a = 1000000007;;

let f x y =
  let rec pow m n b b2 b3 = match n with
      0 -> 1
    | 1 -> ((b mod a) * (b3 mod a)) mod a
    | _->let c = match b2 with
             1 -> (m mod a)
           | _ -> ((b2 mod a)*(b2 mod a)) mod a
         in
         pow m (n/2) ((b mod a)*(b mod a)) c ((if n mod 2 = 0 then 1 else c)*(b3 mod a))
  in
  let g z = Printf.printf "%d\n" z
  in g (pow x y x 1 1);;
Scanf.scanf "%d %d" f;;
