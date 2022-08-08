(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_2_A/review/4847312/tt99kuze/OCaml *)
let count = ref 0 ;;

let bubble_sort a n =
  let rec f flag = if flag then bubble (n - 1) false else ()
  and bubble i flag =
    if i = 0 then f flag
    else if a.(i-1) <= a.(i) then bubble (i - 1) flag
    else (let strage = a.(i) in a.(i) <- a.(i-1); a.(i-1) <- strage; incr count; bubble (i - 1) true)
  in f true ;;

let () =
  let n = Scanf.scanf "%d\n" (fun n -> n) in
  let a = Array.init n (fun _ -> Scanf.scanf "%d " (fun a -> a)) in
  bubble_sort a n;
  a |> Array.iteri (fun i x -> Printf.printf (if i = 0 then "%d" else " %d") x) ;
  print_newline ();
  Printf.printf "%d\n" !count;;
