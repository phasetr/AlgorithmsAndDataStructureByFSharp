(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_11_B/review/2032804/ydash/OCaml *)
type dice = { one : int; two : int; three : int;
              four : int; five : int; six : int}

let right_side {one=a;two=b;three=c;four=d;five=e;six=f} t_f =
  let find l = List.fold_left (fun acc p -> acc || p=t_f) false l in
  if find [b,c;c,e;d,b;e,d] then a
  else if find [a,d;c,a;d,f;f,c] then b
  else if find [a,b;b,f;e,a;f,e] then c
  else if find [a,e;b,a;e,f;f,b] then d
  else if find [a,c;c,f;d,a;f,d] then e
  else f

let () =
  let dice = Scanf.sscanf (read_line ()) "%d %d %d %d %d %d"
               (fun a b c d e f -> {one=a;two=b;three=c;four=d;five=e;six=f}) in
  let n = read_int () in
  let rec loop = function
    | 0 -> ()
    | i -> Scanf.sscanf (read_line ()) "%d %d" (fun a b -> a,b)
           |> right_side dice
           |> Printf.printf "%d\n";
           loop (i-1)
  in loop n
