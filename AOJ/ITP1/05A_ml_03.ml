(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_5_A/review/2962443/napo/OCaml *)
let () =
  let rec f _ =
    let (h, w) = Scanf.sscanf(read_line()) "%d %d" (fun x y -> (x, y)) in
    if h = 0 && w = 0 then ()
    else (
      let row = String.make w '#' in
      for _ = 1 to h do Printf.printf "%s\n" row; done;
      print_newline ();
      f ()
    )
  in f ();;
