(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_6_C/review/1854135/sly/OCaml *)
let () =
  let n = Scanf.scanf "%d\n" (fun x -> x) in
  let d = Array.make_matrix 4 3 (Array.make 10 0) in
  for i = 0 to 3 do
    for j = 0 to 2 do
      d.(i).(j) <- Array.make 10 0
    done
  done;
  for i = 1 to n do
    let b, f, r, v = Scanf.scanf "%d %d %d %d\n" (fun x y z w -> x-1, y-1, z-1, w) in
    d.(b).(f).(r) <- d.(b).(f).(r) + v
  done;

  let sF rs = Array.map string_of_int rs |> Array.to_list |> String.concat " " |> (^) " " in
  let sB fs = Array.map sF fs |> Array.to_list |> String.concat "\n" in
  let sD bs = Array.map sB bs |> Array.to_list |> String.concat "\n####################\n" in

  sD d |> Printf.printf "%s\n"
