(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_5_A/review/1838703/superluminalsloth/OCaml *)
let rec print_rect x =
  let (h,w) = Scanf.scanf "%d %d\n" (fun x y -> (x,y))in
  match (h,w) with
    (0,0) -> ()
  | (h,w) ->
     for i=1 to h do
       for j=1 to w do
         print_string "#"
       done;
       print_newline ();
     done;
     print_newline ();
     print_rect x;;
 let () = print_rect ();;
