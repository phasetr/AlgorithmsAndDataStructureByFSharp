(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_10_C/review/2476020/r6eve/OCaml *)
let max (x : int) y = if x > y then x else y

let lcs (x, y) =
  let m = String.length x in
  let n = String.length y in
  let s = Array.make (n + 1) 0 in
  let t = Array.copy s in
  for i = 1 to m do
    for j = 1 to n do
      t.(j) <- if x.[i-1] = y.[j-1] then s.(j-1) + 1 else max s.(j) t.(j-1)
    done;
    Array.iteri (fun i e -> s.(i) <- e) t;
  done;
  t.(n)

let () =
  let q = Scanf.scanf "%d " (fun q -> q) in
  for _ = 0 to q - 1 do
    Scanf.scanf "%s %s " (fun x y -> x, y) |> lcs |> Printf.printf "%d\n"
  done
