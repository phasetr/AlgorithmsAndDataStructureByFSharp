(* https://atcoder.jp/contests/abc049/submissions/3453531 *)
Scanf.scanf" %s"@@fun s->print_endline@@if Str.(string_match(regexp"^\\s*\\(dream\\|dreamer\\|erase\\|eraser\\)+\\s*$")s 0)then"YES"else"NO"
