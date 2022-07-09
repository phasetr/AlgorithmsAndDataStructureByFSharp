(* https://atcoder.jp/contests/abc044/submissions/2309767 *)
let w = read_line ();;
let h = Hashtbl.create (String.length w);;
String.iter
  (fun c ->
    let v = try Hashtbl.find h c with Not_found -> 0 in
    Hashtbl.replace h c (v + 1))
  w;
(if Hashtbl.fold
      (fun _ v pre -> v mod 2 = 0 && pre) h true then "Yes" else "No")
|> print_endline
