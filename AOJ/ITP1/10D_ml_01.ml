(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_10_D/review/4524472/tt99kuze/OCaml *)
let () =
  let n = Scanf.scanf "%d\n" (fun a -> a) in
  let read () = Array.init n (fun _ -> Scanf.scanf "%f " (fun a -> a)) in
  let x = read () and y = read () in
  let abs_s = Array.mapi (fun i x -> abs_float (x -. y.(i))) x in
  let cal_distance p = (Array.fold_left (fun e x -> e +. x ** p) 0. abs_s) ** (1. /. p) in
  Printf.printf "%10f\n%10f\n%10f\n%10f\n" (cal_distance 1.) (cal_distance 2.) (cal_distance 3.) (Array.fold_left (fun e x -> max e x) 0. abs_s) ;;
