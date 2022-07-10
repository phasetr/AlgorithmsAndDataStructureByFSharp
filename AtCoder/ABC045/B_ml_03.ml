(* https://atcoder.jp/contests/abc045/submissions/8002003 *)
let ss = Array.init 3 @@ fun _ -> read_line ()
let i_s = Array.make 3 0
let rec f c = String.(
    let j = index "abc" c in
    if i_s.(j) >= length ss.(j)
    then Printf.printf "%c\n" "ABC".[j]
    else (i_s.(j) <- i_s.(j) + 1; f ss.(j).[i_s.(j) - 1]))
let _ = i_s.(0) <- 1; f ss.(0).[0]
