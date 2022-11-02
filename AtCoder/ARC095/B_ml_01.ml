(* https://atcoder.jp/contests/abc094/submissions/10051384 *)
let a_s = Array.init (read_int ()) @@ fun _ -> Scanf.scanf " %d" (+) 0
let h = Array.fold_left max 0 a_s
let _ = Array.fold_left (fun b a -> if a < h && abs (a - h / 2) < abs (b - h / 2) then a else b) max_int a_s
        |> Printf.printf "%d %d\n" h
