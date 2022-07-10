(* https://atcoder.jp/contests/abc045/submissions/14889349 *)
Scanf.scanf "%s %s %s" (fun sa sb sc ->
    let rec loop cur ai bi ci =
      match cur with
      | 'a' -> if ai = String.length sa then "A" else loop sa.[ai] (ai + 1) bi ci
      | 'b' -> if bi = String.length sb then "B" else loop sb.[bi] ai (bi + 1) ci
      | 'c' -> if ci = String.length sc then "C" else loop sc.[ci] ai bi (ci + 1)
      | _ -> failwith "??"
    in
    loop 'a' 0 0 0 |> print_endline)
