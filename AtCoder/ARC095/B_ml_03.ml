(* https://atcoder.jp/contests/abc094/submissions/16186378 *)
Scanf.scanf "%d" (
    fun n ->
    let a = Array.init n (fun _ -> Scanf.scanf " %d" (fun a -> a)) in
    Array.sort compare a;

    let am = a.(n - 1) in

    let rec loop i aj bs =
      if i < 0 then aj else
        if abs (a.(i) * 2 - am) < bs then loop (i - 1) a.(i) (a.(i) * 2 - am)
        else loop (i - 1) aj bs
    in
    let aj = loop (n - 2) 0 am in
    Printf.printf "%d %d\n" am aj
  )
