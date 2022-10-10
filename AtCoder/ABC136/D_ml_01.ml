(* https://atcoder.jp/contests/abc136/submissions/7344986 *)
let s = read_line ()
let n = String.length s
let eo, ans = Array.(make 2 0, make n 0)
let g a i = a.(i) <- a.(i) + 1
let rec f i p j = if i < n then
  if p = 'R' then if s.[i] = 'R' then (g eo @@ i mod 2; f (i + 1) p j)
    else (ans.(i - 1) <- eo.(1 - i mod 2); ans.(i) <- eo.(i mod 2) + 1; f (i + 1) 'L' i)
  else if s.[i] = 'L' then (g ans @@ j - (i - j) mod 2; f (i + 1) p j) else (eo.(0) <- 0; eo.(1) <- 0; eo.(i mod 2) <- 1; f (i + 1) 'R' j)
let _ = eo.(0) <- 1; f 1 'R' 0; Array.iteri (fun i n -> Printf.printf (if i = 0 then "%d" else " %d") n) ans; print_newline ()
