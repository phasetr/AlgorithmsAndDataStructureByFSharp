(* https://atcoder.jp/contests/apc001/submissions/2059288 *)
let ask i =
  print_int i;
  print_newline();
  let s = read_line() in
  s
    in

    let rec search : int -> string -> int -> string -> unit = fun l ls r rs ->
      let m = (l+r)/2 in
      let ms = ask m in
      if ms <> "Vacant" then
        if (m-l+1) mod 2 = 0 then
          if ms = ls then
            search l ls m ms
          else
            search m ms r rs
        else
          if ms = ls then
            search m ms r rs
          else
            search l ls m ms
      else
        ()
    in

    let n = read_int() in
    let ls = ask 0 in
    if ls <> "Vacant" then
      let rs = ask (n-1) in
      if rs <> "Vacant" then
        search 0 ls (n-1) rs
      else ()
    else ()
;;
