(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_5_C/review/1838730/superluminalsloth/OCaml *)
let rec print_rect x =
  let (h,w) = Scanf.scanf "%d %d\n" (fun x y -> (x,y) )in
  match (h,w) with
    (0,0) -> ()
  | (h,w) ->
     for i=1 to h do
       for j=1 to w do
         match (i mod 2, j mod 2) with
           (1,1) | (0,0) -> print_string "#"
           | _ -> print_string "."
       done;
       print_newline ();
     done;
     print_newline ();
     print_rect x;;
 let () = print_rect ();;
