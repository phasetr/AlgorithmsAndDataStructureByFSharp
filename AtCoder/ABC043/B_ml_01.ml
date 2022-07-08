(* https://atcoder.jp/contests/abc043/submissions/15290312 *)
Scanf.scanf "%s" (fun s ->
    let n = String.length s in
    let rec loop i acc l =
      if i = n then acc else
        if s.[i] = '0' then loop (i + 1) (acc ^ "0") (l + 1) else
          if s.[i] = '1' then loop (i + 1) (acc ^ "1") (l + 1) else
            let l = max 0 (l - 1) in
            loop (i + 1) (String.sub acc 0 l) l
    in loop 0 "" 0 |> print_endline)
