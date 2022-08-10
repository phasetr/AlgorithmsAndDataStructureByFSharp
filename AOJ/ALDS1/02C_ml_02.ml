(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_2_C/review/2017943/r6eve/OCaml *)
let print_array a =
  Array.iteri (fun i s -> Printf.printf (if i = 0 then "%s" else " %s") s) a;
  print_newline ()

let swap i j a = let tmp = a.(i) in a.(i) <- a.(j); a.(j) <- tmp

let bubble_sort a n cmp =
  let rec bubble i flag =
    if i = 0 then doit flag
    else if cmp a.(i-1) a.(i) <= 0 then bubble (i - 1) flag
    else (swap i (i - 1) a; bubble (i - 1) true)
  and doit flag =
    if flag then bubble (n - 1) false
  in doit true

let selection_sort a n cmp =
  let rec select j minj =
    if j >= n then minj
    else select (j + 1) (if cmp a.(j) a.(minj) < 0 then j else minj)
  and doit i =
    if i < n then begin
        let j = select i i in
        if j <> i then swap i j a;
        doit (i + 1)
      end in
  doit 0

let cmp_card x y =
  let num_of_char c = Char.code c - Char.code '0' in
  compare (num_of_char x.[1]) (num_of_char y.[1])

let stable_p a b n =
  let rec doit i =
    if i = n then true
    else if a.(i) <> b.(i) then false
    else doit (i + 1)
  in doit 0

let () =
  let n = read_int () in
  let a = Array.of_list (Str.split (Str.regexp " ") (read_line ())) in
  let b = Array.copy a in
  bubble_sort a n cmp_card;
  selection_sort b n cmp_card;
  print_array a;
  print_endline "Stable";
  print_array b;
  print_endline (if stable_p a b n then "Stable" else "Not stable")
