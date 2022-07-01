(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_3_B/review/2289854/suibaka/OCaml *)
let rec solve cnt =
  let x = Scanf.scanf "%d " (fun x -> x) in
  if x != 0 then (
    Printf.printf "Case %d: %d\n" cnt x;
    solve (cnt+1)
  )
let _ = solve 1;;
