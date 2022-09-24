(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_13_C/review/2469282/rabbisland/OCaml *)
open Printf
open Scanf

let id x = x

type state = {h : int; sp : int; bd : int array}

let () =
  let n = 4 in
  let isp = ref 0 in
  let bd = Array.init (n * n) (fun i -> let v = scanf "%d " id in if v = 0 then isp := i; v) in
  let dist bd =
    Array.fold_left
      (fun (i, d) x ->
        if x = 0 then (i+1, d)
        else
          let r, c = (i / n, i mod n) in
          let y = x - 1 in
          let r', c' = (y / n, y mod n) in
          (i + 1, d + abs (r - r') + abs (c - c'))
      ) (0, 0) bd |> snd in
  let rec dfs st d pd limit =
    if st.h = 0 then Some d
    else if d + st.h > limit then None
    else
      List.fold_left
        (fun v (dx, dy) ->
          match v with
            Some _ -> v
          | None ->
             let x, y = (st.sp / n, st.sp mod n) in
             let nx, ny = (dx + x, dy + y) in
             let npd = 2 * dx + dy in
             if 0 <= nx && nx < n && 0 <= ny && ny < n && npd + pd <> 0 then
               let nsp = n * nx + ny in
               let nbd = Array.copy st.bd in
               begin
                 nbd.(st.sp) <- st.bd.(nsp);
                 nbd.(nsp) <- 0;
                 let nst = {h = dist nbd; sp = nsp; bd = nbd} in
                 dfs nst (d+1) npd limit
               end
             else None
        ) None [(1,0);(0,1);(-1,0);(0,-1)]
  in
  let rec loop st limit =
    if limit = 100 then failwith "15 puzzle"
    else
      match dfs st 0 0 limit with
        None -> loop st (limit + 1)
      | Some x -> x
  in
  let ih = dist bd in loop {h = ih; sp = !isp; bd = bd} ih |> printf "%d\n"
