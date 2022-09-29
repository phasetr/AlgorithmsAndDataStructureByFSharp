(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_14_D/review/2480999/rabbisland/OCaml *)
let id x = x

let make_sa s =
  let sl = String.length s in
  let sa = Array.init (sl+1) id in
  let rank = Array.init (sl+1) (fun i -> if i = sl then (-1) else Char.code s.[i]) in
  let ta = Array.make (sl+1) 0 in
  let cmp k i j =
    if rank.(i) = rank.(j) then
      let rik = if i + k <= sl then rank.(i+k) else (-1) in
      let rjk = if j + k <= sl then rank.(j+k) else (-1) in
      rik - rjk
    else rank.(i) - rank.(j) in
  let ra_rank k =
    let rec iter i =
      if i > sl then ()
      else begin
          ta.(sa.(i)) <- ta.(sa.(i-1)) + (if cmp k sa.(i) sa.(i-1) > 0 then 1 else 0);
          iter (i+1)
        end in
    let rec copy i =
      if i > sl then ()
      else begin
          rank.(i) <- ta.(i);
          copy (i+1)
        end in
    iter 1;
    copy 0 in
  let rec sort_sa k =
    if k > sl then ()
    else begin
        Array.fast_sort (cmp k) sa;
        ra_rank k;
        sort_sa (2 * k)
      end in
  sort_sa 1; sa

let string_search sa s p =
  let sl = String.length s in
  let pl = String.length p in
  let rec search l r =
    if r - l <= 1 then
      try String.sub s sa.(r) pl = p with _ -> false
    else
      let m = (l + r) / 2 in
      match compare (String.sub s sa.(m) (min pl (sl - sa.(m)))) p with
        0 -> true
      | x when x < 0 -> search m r
      | _ -> search l m
  in
  search 0 (sl+1)

let () =
  let t = read_line () in
  let q = read_int () in
  let sa = make_sa t in
  let rec loop x =
    if x = 0 then ()
    else let p = read_line () in
         (if string_search sa t p then "1" else "0") |> print_endline;
         loop (x-1)
  in loop q
