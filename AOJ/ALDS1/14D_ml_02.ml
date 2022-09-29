(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_14_D/review/2458788/r6eve/OCaml *)
exception Not_equal of int

let cmp_sa rank a b n k =
  if rank.(a) <> rank.(b) then compare rank.(a) rank.(b)
  else
    compare
      (if a + k <= n then rank.(a+k) else (-1))
      (if b + k <= n then rank.(b+k) else (-1))

let construct_sa t n =
  let sa = Array.make (n + 1) 0 in
  let rank = Array.make (n + 1) 0 in
  let tmp = Array.make (n + 1) 0 in
  for i = 0 to n - 1 do
    sa.(i) <- i;
    rank.(i) <- Char.code t.[i];
  done;
  sa.(n) <- n;
  rank.(n) <- (-1);
  let rec doit k =
    if k > n then ()
    else begin
        Array.fast_sort (fun a b -> cmp_sa rank a b n k) sa;
        tmp.(sa.(0)) <- 0;
        for i = 1 to n do
          tmp.(sa.(i)) <-
            tmp.(sa.(i-1)) + (if cmp_sa rank sa.(i-1) sa.(i) n k = (-1) then 1 else 0);
        done;
        for i = 0 to n do rank.(i) <- tmp.(i) done;
        doit (2 * k)
      end in
  doit 1;
  sa

let range_cmp t n offset p k =
  let m = n - offset in
  let m = if m < k then m else k in
  try
    for i = 0 to m - 1 do
      if t.[i+offset] <> p.[i] then
        raise (Not_equal (compare t.[i+offset] p.[i]));
    done;
    if m = k then 0
    else (-1)
  with Not_equal i -> i

let () =
  let t = read_line () in
  let n = String.length t in
  let sa = construct_sa t n in
  let q = read_int () in
  for _ = 0 to q - 1 do
    let p = read_line () in
    let k = String.length p in
    let rec doit l r =
      if r - l <= 1 then l
      else
        let m = (l + r) / 2 in
        if range_cmp t n sa.(m) p k <= 0 then doit m r
        else doit l m in
    let l = doit 0 (n + 1) in
    Printf.printf "%d\n" (if range_cmp t n sa.(l) p k = 0 then 1 else 0);
  done
