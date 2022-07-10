(* https://atcoder.jp/contests/abc045/submissions/10316425 *)
let ans sa sb sc =
  let na = String.length sa
  and nb = String.length sb
  and nc = String.length sc
  in
  let rec f ia ib ic = function
      'a' -> if ia = na then "A"  else f (ia+1) ib ic sa.[ia]
    | 'b' -> if ib = nb then "B" else f ia (ib+1) ic sb.[ib]
    | _ -> if ic = nc then "C" else f ia ib (ic+1) sc.[ic]
  in f 0 0 0 'a';;

Scanf.scanf "%s\n%s\n%s" (fun sa sb sc -> print_string (ans sa sb sc))

