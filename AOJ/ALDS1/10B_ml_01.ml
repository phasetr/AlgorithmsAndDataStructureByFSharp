(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_10_B/review/5462528/lrmystp/OCaml *)
let inf = max_int / 3

let () =
  Scanf.scanf "%d" @@ fun n -> let a = Array.init n (fun i -> Scanf.scanf " %d %d" (fun a b -> a, b)) in
  let dp = Array.make_matrix n n inf in
  for i = 0 to n-1 do
    dp.(i).(i) <- 0;
  done;
  for w = 1 to n-1 do
    for i = 0 to n-w-1 do
      let j = i+w in
      for k = i+1 to j do
        let (ri, _), (rk, _), (_, cj) = a.(i), a.(k), a.(j) in
        dp.(i).(j) <- min dp.(i).(j)
                        (dp.(i).(k-1) + dp.(k).(j) + ri * rk * cj);
      done;
    done
  done;

  Printf.printf "%d\n" dp.(0).(n-1)
