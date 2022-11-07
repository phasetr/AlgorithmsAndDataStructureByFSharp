(* https://atcoder.jp/contests/abc084/submissions/17101936 *)
Scanf.scanf "%d" (fun n ->
    let csf = Array.init (n - 1) (fun _ -> Scanf.scanf " %d %d %d" (fun c s f -> c, s, f)) in
    for i = 0 to n - 1 do
      let rec loop i time =
        if i = n - 1 then Printf.printf "%d\n" time else
          let (c, s, f) = csf.(i) in
          if time < s then loop (i + 1) (s + c)
          else loop (i + 1) ((time + f - 1) / f * f + c)
      in
      loop i 0
    done
  )
