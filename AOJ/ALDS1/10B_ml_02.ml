(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_10_B/review/2437494/r6eve/OCaml *)
let mcm p n =
  let m = Array.make_matrix (n + 1) (n + 1) max_int in
  for i = 1 to n do m.(i).(i) <- 0 done;
  for l = 1 to n - 1 do
    for i = 1 to n - l do
      let j = i + l in
      for k = i to j - 1 do
        m.(i).(j) <- min m.(i).(j) (m.(i).(k) + m.(k+1).(j) + p.(i-1)*p.(k)*p.(j))
      done
    done
  done;
  m.(1).(n)

let () =
  let n = read_int () in
  let p = Array.make (n + 1) 0 in
  for i = 0 to n - 1 do
    let (r, c) = Scanf.scanf "%d %d\n" (fun r c -> (r, c)) in
    p.(i) <- r;
    p.(i+1) <- c;
  done;
  mcm p n |> Printf.printf "%d\n"
