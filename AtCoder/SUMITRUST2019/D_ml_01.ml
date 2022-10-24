(* https://atcoder.jp/contests/sumitrust2019/submissions/10247238 *)
let ans, n = ref 0, read_int ()
let s = read_line ()
let _ =
  for i = 0 to 999 do
    if try
        List.fold_left
          (fun p n -> String.index_from s p (Char.chr (n + 48)) + 1)
          0
          [i / 100; i / 10 mod 10; i mod 10] >= 0
      with _ -> false
    then incr ans done; Printf.printf "%d\n" !ans
