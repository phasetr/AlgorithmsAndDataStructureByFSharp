(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_1_A/review/5478623/que0/OCaml *)
let print_array a =
  Array.fold_left (fun a n -> a ^ " " ^ string_of_int n) "" a |> String.trim |> print_endline
let _ =
  let insert_sort_a a =
    for i=1 to Array.length a -1 do
      print_array a;
      let key = a.(i) and j = ref (i - 1) in
      while !j >= 0 && a.(!j) > key do
        a.(!j+1) <- a.(!j);
        j := !j - 1;
        a.(!j+1) <- key
      done
    done in
  let n = Scanf.scanf "%d " (fun x -> x) in
  let a = Array.make n 0 in
  for i=0 to (n-1) do Scanf.scanf "%d " (fun x -> a.(i)<-x) done;
  insert_sort_a a;
  print_array a
