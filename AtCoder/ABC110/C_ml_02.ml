(* https://atcoder.jp/contests/abc110/submissions/13604116 *)
Scanf.scanf "%s %s" (fun s t ->
    let n = String.length s in
    let cp = Array.make 26 '.' in
    let cq = Array.make 26 '.' in
    let rec loop i =
      if i = n then "Yes" else
        let p = s.[i] in
        let q = t.[i] in
        let pi = int_of_char p - 97 in
        let qi = int_of_char q - 97 in
        if (cp.(pi) = '.' || cp.(pi) = q) &&
             (cq.(qi) = '.' || cq.(qi) = p)  then (
          cp.(pi) <- q;
          cq.(qi) <- p;
          loop (i + 1)
        ) else "No"
    in
    print_endline @@ loop 0
  )
