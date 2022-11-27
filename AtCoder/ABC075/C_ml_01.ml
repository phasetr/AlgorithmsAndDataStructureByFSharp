(* https://atcoder.jp/contests/abc075/submissions/9144314 *)
let n, m, g, c = Scanf.scanf " %d %d" @@ fun a b -> a, b, Array.make a [], ref 0
let f v u = g.(v - 1) <- u - 1 :: g.(v - 1)
let es = Array.init m @@ fun _ -> Scanf.scanf " %d %d" @@ fun a b -> f a b; f b a; [a - 1; b - 1]
let rec h v e vs = vs.(v) <- true; incr c; List.(iter (fun u -> if not (vs.(u) || mem v e && mem u e) then h u e vs) g.(v))
let _ = Array.(fold_left (fun b e -> c := 0; h 0 e @@ make n false; if !c < n then b + 1 else b) 0 es) |> Printf.printf "%d\n"
