(* https://atcoder.jp/contests/abc125/submissions/5148040 *)
let () =
  Scanf.scanf "%d" @@ fun n ->
  let a = Array.init n (fun _ -> Scanf.scanf " %d" ((+) 0)) in
  Array.sort (fun x y -> abs x - abs y) a;

  let s = Array.fold_left (fun x y -> x + abs y) 0 a in
  let c = Array.fold_left (fun x y -> if y < 0 then x+1 else x) 0 a in
  Printf.printf "%d\n" (if c mod 2 = 0 then s else s - 2 * abs a.(0))
