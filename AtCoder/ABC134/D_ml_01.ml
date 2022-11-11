(* https://atcoder.jp/contests/abc134/submissions/9793454 *)
let n = read_int ()
let cs, a_s = Array.(make (n + 1) 0, init n @@ fun _ -> Scanf.scanf " %d" (+) 0)
let _ =
  for i = n downto 1 do
    for k = 2 to n / i do
      cs.(i) <- cs.(i) lxor cs.(k * i)
    done;
    cs.(i) <- cs.(i) lxor a_s.(i - 1)
  done;
  Array.(print_int (fold_left (+) 0 cs);
         iteri (fun i c -> if c = 1 then Printf.printf (if i = 1 then "\n%d" else " %d") i) cs);
  print_newline ()
