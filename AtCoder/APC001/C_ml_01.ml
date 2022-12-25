(* https://atcoder.jp/contests/apc001/submissions/17178051 *)
Scanf.sscanf (read_line ()) "%d" (fun n ->
    print_endline "0";
    let judge s = if s = "Male" then 0 else 1 in
    let s = read_line () in
    if s = "Vacant" then () else
      let rec loop l r e =
        let m = (l + r) / 2 in
        let () = Printf.printf "%d\n%!" m in
        let s = read_line () in
        if s = "Vacant" then () else
          let v = judge s in
          if (m - l - v + e + 2) mod 2 = 0 then loop (m + 1) r ((m + 1 - l - e) mod 2)
          else loop l m e
      in
      loop 0 n (judge s)
  )
