(* https://atcoder.jp/contests/abc130/submissions/5970685 *)
Scanf.scanf "%d %d" @@ fun n k ->
let a = Array.init n (fun _ -> Scanf.scanf " %d" ((+) 0)) in
let rec loop z s l r =
  if s >= k then if l = n-1 then z else loop z (s - a.(l)) (l+1) r
  else let z = z - (r - l) in if r = n then z else loop z (s + a.(r)) l (r+1)
in
loop ((n+1)*n/2) 0 0 0 |> Printf.printf "%d\n"
