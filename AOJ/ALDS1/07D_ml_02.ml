(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_7_D/review/2431816/r6eve/OCaml *)
let () =
  let open Queue in
  let n = read_int () in
  let preorder = create () in
  for _ = 0 to n - 1 do
    add (Scanf.scanf "%d " (fun i -> i)) preorder;
  done;
  let inorder = Array.init n (fun _ -> Scanf.scanf "%d " (fun i -> i)) in
  let t = Array.make (40 + 1) 0 in
  Array.iteri (fun i e -> t.(e) <- i) inorder;
  let postorder = create () in
  let rec doit l r =
    if l >= r then ()
    else begin
        let root = take preorder in
        let m = t.(root) in
        doit l m;
        doit (m + 1) r;
        add root postorder
      end in
  doit 0 n;
  print_int (take postorder);
  iter (fun e -> print_string " "; print_int e) postorder;
  print_newline ()
