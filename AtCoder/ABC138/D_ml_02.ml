(* https://atcoder.jp/contests/abc138/submissions/7047345 *)
open Printf
open Scanf

let () =
  let n, q = scanf " %d %d" (fun x y -> x, y) in
  let g = Array.make n [] in
  for _ = 0 to n - 2 do
    let a, b = scanf " %d %d" (fun x y -> x - 1, y - 1) in
    g.(a) <- b :: g.(a);
    g.(b) <- a :: g.(b);
  done;
  let ans = Array.make n 0 in
  for _ = 0 to q - 1 do
    let p, x = scanf " %d %d" (fun x y -> x - 1, y) in
    ans.(p) <- ans.(p) + x;
  done;
  let rec dfs u p = g.(u) |> List.iter @@ fun v ->
    if v <> p then begin
      ans.(v) <- ans.(v) + ans.(u);
      dfs v u
    end in
  dfs 0 (-1);
  for i = 0 to n - 1 do
    printf "%d " ans.(i)
  done;
  print_newline ();
