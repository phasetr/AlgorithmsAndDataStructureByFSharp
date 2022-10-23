(* https://atcoder.jp/contests/abc130/submissions/5999604 *)
(* O(n) *)
let n, k = Scanf.scanf " %d %d" @@ fun a b -> a, b
let a_s = Array.init n @@ fun _ -> Scanf.scanf " %d" @@ (+) 0
let sum = ref 0
let ans = ref 0
let _ =
  let j = ref 0 in
  for i = 0 to n - 1 do
    while !j < n && !sum < k do sum := !sum + a_s.(!j); incr j done;
    if !sum >= k then ans := !ans + n - !j + 1;
    sum := !sum - a_s.(i)
  done;
  Printf.printf "%d\n" !ans
