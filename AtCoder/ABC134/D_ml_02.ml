(* https://atcoder.jp/contests/abc134/submissions/6466829 *)
let () = Scanf.scanf "%d\n" @@ fun n ->
  let as_ = Array.init n @@ fun _ -> Scanf.scanf "%d " @@ fun a -> a in
  let ans = Array.make (n + 1) 0 in
  for i = n downto 1 do
    ans.(i) <- Array.fold_left ( lxor ) as_.(i - 1) @@
      Array.init (n / i - 1) @@ fun j -> ans.(i * (j + 2))
  done;
  match Array.fold_left ( + ) 0 ans with
  | 0 -> print_endline "0"
  | x ->
      Printf.printf "%d\n" x;
      for i = 1 to n do
        if ans.(i) = 1 then Printf.printf "%d " i
      done;
      print_newline ()
