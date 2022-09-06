(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_7_D/review/5526975/que0/OCaml *)
open Array
let n = read_int()
let pt = init n (fun _ -> (Scanf.scanf "%d " (fun x -> x)))
let it = init n (fun _ -> (Scanf.scanf "%d " (fun x -> x)));;
let bu = Buffer.create 99;;

let ary_srch a x =
  let rec a_s i = if a.(i) = x then i else a_s (i + 1) in
  a_s 0

let rec fALDS1_7_D pt it n =
  match n with
  | 0 -> ()
  | 1 -> Buffer.add_string bu ((string_of_int pt.(0)) ^ " ")
  | n ->
    let h = ary_srch it pt.(0) in
    let m = n - h - 1 in (
    fALDS1_7_D (sub pt 1 h) (sub it 0 h) h;
    fALDS1_7_D (sub pt (1 + h) m) (sub it (1+ h) m) m;
    fALDS1_7_D [|pt.(0)|] [||] 1)
;;
fALDS1_7_D pt it n;
print_endline (String.trim (Buffer.contents bu))
