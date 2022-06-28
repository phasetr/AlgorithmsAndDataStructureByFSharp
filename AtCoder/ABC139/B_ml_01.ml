(* https://atcoder.jp/contests/abc139/submissions/16571286 *)
let rec solve target now ans x =
  if target <= now then ans else solve target (now-1+x) (ans+1) x;;
let () =
  Scanf.scanf "%d %d\n" @@
    fun a b -> Printf.printf "%d\n" (solve b 1 0 a)
