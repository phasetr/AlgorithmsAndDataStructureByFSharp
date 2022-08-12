(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_2_D/review/2410909/r6eve/OCaml *)
let cnt = ref 0

let insertion_sort (a : int array) n g =
  for i = g to n - 1 do
    let v = a.(i) in
    let j = ref (i - g) in
    while !j >= 0 && a.(!j) > v do
      a.(!j+g) <- a.(!j);
      j := !j - g;
      incr cnt;
    done;
    a.(!j+g) <- v;
  done

let generate_g n =
  let rec doit i g acc =
    if g > n then acc
    else doit (i + 1) (int_of_float (4.**(float_of_int i) +. 3.*.2.**(float_of_int (i - 1)) +. 1.)) (g :: acc) in
  doit 1 1 []

let shell_sort (a : int array) n =
  cnt := 0;
  let g = generate_g n in
  List.iter (fun g -> insertion_sort a n g) g;
  g

let () =
  let n = read_int () in
  let a = Array.init n (fun _ -> read_int ()) in
  let g = shell_sort a n in
  Printf.printf "%d\n" (List.length g);
  List.iteri (fun i n -> if i <> 0 then print_string " "; print_int n) g;
  print_newline ();
  Printf.printf "%d\n" !cnt;
  Array.iter (fun n -> Printf.printf "%d\n" n) a
