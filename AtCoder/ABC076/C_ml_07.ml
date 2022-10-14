(* https://atcoder.jp/contests/abc076/submissions/16750136 *)
Scanf.scanf "%s %s" (fun s t ->
    let n = String.length s in
    let tn = String.length t in

    let check p =
      let rec loop j =
        if j = tn then true else
          if s.[p + j] = t.[j] || s.[p + j] = '?' then loop (j + 1) else false
      in
      loop 0
    in

    let make p =
      String.init n (fun i ->
          if s.[i] <> '?' then s.[i] else
            if i < p || i >= p + tn then 'a' else t.[i - p]
        )
    in

    let rec loop i acc =
      if i < 0 then acc else
        let acc = if check i then min acc (make i) else acc in
        loop (i - 1) acc
    in
    let r = loop (n - tn) "{" in
    print_endline @@ if r = "{" then "UNRESTORABLE" else r
  )
