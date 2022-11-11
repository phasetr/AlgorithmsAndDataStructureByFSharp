(* https://atcoder.jp/contests/abc134/submissions/6463573 *)
let readInt () = Scanf.scanf " %d" (fun x -> x)

let solve n a =
  let b = Array.make n (-1) in
  let rec go i =
    if i < 1 then ()
    else
    let rec sumPrev s j =
      if j > n then s else sumPrev (s + b.(j-1)) (j + i)
    in
    let tot = sumPrev 0 (2*i) mod 2 in
    (*Printf.printf "%d %d %d\n" i tot a.(i-1);*)
    b.(i-1) <- if tot = a.(i-1) then 0 else 1;
    go (i-1)
  in go n;
  let rec go (k, acc) i =
    if i < 1 then (k, acc)
    else go (if b.(i-1) = 1 then (k+1, i :: acc) else (k, acc)) (i-1)
  in go (0, []) n

let main () =
  let n = readInt () in
  let a = Array.init n (fun _ -> readInt ()) in
  let (k, ans) = solve n a in
  Printf.printf "%d\n" k;
  ans |> List.iter (fun x -> Printf.printf "%d " x);
  print_endline ""

let () = main ()
