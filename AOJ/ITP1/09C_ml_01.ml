(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_9_C/review/1855827/superluminalsloth/OCaml *)
let n = read_int ();;
let rec play i t h = match i with
  | 0 -> Printf.printf "%d %d\n" t h
  | i -> ( match Scanf.scanf "%s %s\n" (fun x y -> compare x y) with
           | 0 -> play (i-1) (t+1) (h+1)
           | 1 -> play (i-1) (t+3) h
           | -1 -> play (i-1) t (h+3)
           | _ -> play (i-1) t h )
    in play n 0 0;;
