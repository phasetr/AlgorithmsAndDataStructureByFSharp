(* https://atcoder.jp/contests/abc094/submissions/2911675 *)
let () =
  Scanf.scanf "%d" @@ fun n ->
  let a = Array.init n (fun _ -> Scanf.scanf " %d" ((+) 0)) in
  Array.sort (-) a;
  let m = a.(n-1) in
  let r = Array.fold_left (fun r e ->
    if abs (m-2*e) < abs (m-2*r) then e else r) a.(0) a in
  Printf.printf "%d %d\n" m r
