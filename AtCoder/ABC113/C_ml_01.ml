(* https://atcoder.jp/contests/abc113/submissions/7199674 *)
let n, m = Scanf.scanf " %d %d" @@ fun a b -> a, b
let yps = Array.init m @@ fun i -> Scanf.scanf " %d %d" @@ fun a b -> b, a, i
let rs, ns = Array.(make (n + 1) 1, make m "")
let _ = Array.(sort compare yps; iter (fun (_, p, i) -> ns.(i) <- Printf.sprintf "%06d%06d" p rs.(p); rs.(p) <- rs.(p) + 1) yps; iter print_endline ns)
