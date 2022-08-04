(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_1_A/review/4706447/maimai07/OCaml *)
let () =
  let rec insertionSort arr n m =
    for i = 0 to n - 2 do Printf.printf "%d " arr.(i) done;
    Printf.printf "%d\n" arr.(n-1);
    if m = n then ()
    else
      let v = arr.(m) in
      let j = ref (m - 1) in
      while !j >= 0 && arr.(!j) > v do arr.(!j+1) <- arr.(!j); j := !j - 1 done;
      arr.(!j+1) <- v; insertionSort arr n (m+1) in
  Scanf.scanf "%d\n"
  @@ fun n -> let arr = Array.init n
                        @@ fun _ -> Scanf.scanf "%d " @@ fun d -> d in insertionSort arr n 1
