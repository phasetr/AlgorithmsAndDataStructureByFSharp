(* https://atcoder.jp/contests/abc107/submissions/4436816 *)
let rec for_fold a b v f = if a >= b then v else for_fold (a+1) b (f a v) f
let () =
  Scanf.scanf "%d %d" @@
    fun n k ->
    let x = Array.init n (fun _ -> Scanf.scanf " %d" ((+) 0)) in
    for_fold 0 (n-k+1) 10101010101010 (fun i v ->
        let l, r = x.(i), x.(i+k-1) in
        if r <= 0 || l >= 0 then min v @@ max (abs l) (abs r)
        else min v @@ min (2 * r - l) (r - 2 * l))
    |> Printf.printf "%d\n"
