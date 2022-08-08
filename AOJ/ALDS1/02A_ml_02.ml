(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_2_A/review/5483277/que0/OCaml *)
let n = read_int ()
let a = Array.make n 0;;
for i = 0 to n-1 do
  a.(i) <- Scanf.scanf "%d " (fun a -> a)
done;;
let n_swap = ref 0;;
let out_s = ref "";;
for i = 0 to n-1 do
  for j = n-1 downto i+1 do
    if a.(j) < a.(j-1)
    then begin
        let s = a.(j) in
        a.(j) <- a.(j-1);
        a.(j-1) <- s;
        n_swap := !n_swap + 1
      end
  done;
  out_s := !out_s ^ (Printf.sprintf "%d " a.(i))
done;
Printf.printf "%s\n%d\n" (String.trim !out_s) !n_swap
