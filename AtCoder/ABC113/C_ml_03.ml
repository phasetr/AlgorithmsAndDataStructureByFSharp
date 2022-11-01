(* https://atcoder.jp/contests/abc113/submissions/12858655 *)
Scanf.scanf "%d %d" (fun n m ->
    let pref = Array.make n 0 in
    let py = Array.init m (fun i -> Scanf.scanf " %d %d" (fun p y -> p, y, i)) in
    let id = Array.make m "" in
    Array.sort compare py;
    Array.iter (fun (p, y, i) ->
        pref.(p - 1) <- pref.(p - 1) + 1;
        id.(i) <- Printf.sprintf "%06d%06d" p pref.(p - 1)
      ) py;
    Array.iter print_endline id
  )
