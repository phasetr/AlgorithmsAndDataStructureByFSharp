(* https://atcoder.jp/contests/abc124/submissions/5896036 *)
(* O(n) *)
let n, k = Scanf.scanf " %d %d" @@ fun a b -> a, b
let s = Scanf.scanf " %s" @@ fun s -> s
let rec f acc i c m =
  if i >= n then List.rev @@ (if c = '1' then m :: acc else 0 :: m :: acc)
  else if s.[i] <> c then f (m :: acc) (i + 1) s.[i] 1
  else f acc (i + 1) s.[i] (m + 1)
let base = f [] 0 '1' 0 |> Array.of_list
let m = Array.length base
let sums = Array.make (m + 1) 0
let ans = ref 0
let _ =
  Array.iteri (fun i c -> sums.(i + 1) <- sums.(i) + c) base;
  let i = ref 0 in
  while !i <= m do
    let r = min m @@ !i + 2 * k + 1 in
    ans := max !ans @@ sums.(r) - sums.(!i);
    i := !i + 2
  done;
  Printf.printf "%d\n" !ans
