(* https://atcoder.jp/contests/abc044/submissions/5903395 *)
(* O(n) *)
let w = read_line ();;
let n = String.length w;;
for i = Char.code 'a' to Char.code 'z' do
  let c = ref 0 in
  String.iter (fun x -> if x = Char.chr i then incr c) w;
  if !c mod 2 <> 0 then (print_endline "No"; exit 0)
done;
print_endline "Yes";;
