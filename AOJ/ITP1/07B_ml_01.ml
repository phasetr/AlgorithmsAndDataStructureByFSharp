(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_7_B/review/4968655/tonooo71/OCaml *)
let rec scan () =
  let n, x = Scanf.sscanf (read_line ()) "%d %d" (fun a b -> (a, b)) in
  if (n + x) = 0 then ()
  else begin
    let rec a_inc a b cnt =
      if a > (x - 1) / 3 then cnt
      else b_inc a b cnt
    and b_inc a b cnt =
      if b > (x - 1) / 2 then a_inc (a + 1) (a + 2) cnt
      else b_inc a (b + 1) (cnt + (if (b + 1) <= (x - a - b) && n >= (x - a - b) then 1 else 0))
    in
    Printf.printf "%d\n" (a_inc 1 2 0);
    scan ()
  end

let () = scan ()
