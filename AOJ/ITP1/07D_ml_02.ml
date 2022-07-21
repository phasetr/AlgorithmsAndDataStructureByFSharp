(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_7_D/review/4466752/tt99kuze/OCaml *)
let () =
  let n, m, l = Scanf.scanf "%d %d %d\n" (fun x y z -> x, y, z) in
  let a = Array.make_matrix n m 0 in
  let b = Array.make_matrix l m 0 in
  let c = Array.make_matrix n l 0 in
  let map2_product xs ys = (* Array.map2 *)
    let n = Array.length xs in
    let zs = Array.make n 0 in
    for i = 0 to (n - 1) do
      zs.(i) <- xs.(i) * ys.(i)
    done;
    zs
  in
  for i = 0 to (n-1) do
    for j = 0 to (m-1) do
      a.(i).(j) <- Scanf.scanf "%d " (fun x -> x)
    done
  done;
  for i = 0 to (m-1) do
    for j = 0 to (l-1) do
      b.(j).(i) <- Scanf.scanf "%d " (fun x -> x)
    done
  done;
  for i = 0 to (n-1) do
    for j = 0 to (l-1) do
      c.(i).(j) <- (map2_product a.(i) b.(j)
                    |> Array.fold_left (fun x y -> x + y) 0)
    done
  done;
  let sN ls = Array.map string_of_int ls |> Array.to_list |> String.concat " " in
  let sC ns = Array.map sN ns |> Array.to_list |> String.concat "\n" in
  sC c |> Printf.printf "%s\n" ;;
