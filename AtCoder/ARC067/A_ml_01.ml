(* https://atcoder.jp/contests/abc052/submissions/6116847 *)
(* O(n^2) *)
let n = read_int ()
let is_prime n =
  if n <= 1 then false
  else
    let rec loop i =
      if i * i > n then true
      else if n mod i = 0 then false
      else loop @@ i + 1 in
    loop 2
let rec div_count n i = if n mod i <> 0 then 0 else 1 + div_count (n / i) i
let ans = ref 1
let _ =
  for i = 2 to n do
    if is_prime i then 
      let c = ref 0 in
      for j = 2 to n do c := !c + div_count j i done;
      ans := !ans * (!c + 1) mod 1_000_000_007 done;
  Printf.printf "%d\n" @@ !ans
