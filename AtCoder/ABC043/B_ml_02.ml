(* https://atcoder.jp/contests/abc043/submissions/7993860 *)
let s = read_line ();;
let cs, i = Array.make 10 ' ', ref 0;;
let _ = String.(iter (function
                    |'B' -> i := max 0 @@ !i - 1
                    | c -> cs.(!i) <- c; incr i) s;
                print_endline @@ init !i @@ Array.get cs)
