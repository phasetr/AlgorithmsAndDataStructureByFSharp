(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_4_D/review/4454137/tt99kuze/OCaml *)
let ()  =
  let n = Scanf.scanf "%d\n" (fun n -> n) in
  let as_ = Array.init n (fun _ -> Scanf.scanf "%d " (fun a -> a)) in
  Array.fold_left (fun (minm, maxm, sum) a -> (ref (min !minm a), ref(max !maxm a), ref (!sum + a))) (ref max_int, ref min_int, ref 0) as_
  |> (fun (x, y, z) -> Printf.printf "%d %d %d\n" !x !y !z) ;;
