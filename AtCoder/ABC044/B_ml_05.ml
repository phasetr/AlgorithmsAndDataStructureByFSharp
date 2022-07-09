(* https://atcoder.jp/contests/abc044/submissions/2139288 *)
let arr_of_str s = Array.init (String.length s) (fun i -> s.[i]);;
let f b c = b lxor (1 lsl (int_of_char c - 97));;
let st = Scanf.scanf "%s" arr_of_str |> Array.fold_left f 0 in
    print_endline (if st = 0 then "Yes" else "No")
