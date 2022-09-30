(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_1_B/review/1882433/superluminalsloth/OCaml *)
let pow x y z =
  let mult x1 y1 = ((x1 mod z)*(y1 mod z)) mod z in
  let rec f m n odd b = match n with
      0 -> 1
    | 1 -> mult m odd
    | _ -> let t = if n mod 2 = 1 then mult odd b else odd
           in f (mult m m) (n/2) t (mult b b)
  in f x y 1 x;;

let () =
  let f x y = pow x y 1000000007 |> Printf.printf "%d\n"
  in Scanf.scanf "%d %d\n" f;;
