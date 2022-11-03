(* https://atcoder.jp/contests/keyence2020/submissions/9571930 *)
let () =
  let main () =
    let n = int_of_string (read_line ()) in
    let xl = Array.init n (fun _ -> Scanf.scanf " %d %d" (fun x l -> x + l, x - l)) in
    Array.sort compare xl;
    let _, m = Array.fold_left (fun (left, m) (r, l) ->
                   if l >= left then (r, m + 1) else (left, m)) (-1_000_000_001, 0) xl
    in
    Printf.printf "%d\n" m
  in
  main ()
