(* https://atcoder.jp/contests/abc142/submissions/8100193 *)
let scan_int () = Scanf.scanf " %d" (fun x -> x)
let print_int n = Printf.printf "%d\n" n

let rec gcd a b = if a mod b = 0 then b else gcd b (a mod b)

let rec div h d = if h mod d = 0 then div (h/d) d else h

let rec solve i h ret =
  if i * i > h then
    if h = 1 then ret + 1
    else ret + 2
  else
    if h mod i = 0 then solve (i+1) (div h i) (ret+1)
    else solve (i+1) h ret

let () =
  let a = scan_int() and b = scan_int() in
  print_int (solve 2 (gcd a b) 0)
