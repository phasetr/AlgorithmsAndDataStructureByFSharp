(* https://atcoder.jp/contests/agc033/submissions/5882784 *)
(* O(h w) *)
let h, w = Scanf.scanf " %d %d" @@ fun a b -> a, b
let q = Queue.create ()
let ds = Array.make_matrix h w @@ -1
let a_ss = Array.init h @@ fun i -> Array.init w @@ fun j -> Scanf.scanf " %c" @@ fun a ->
  if a = '#' then (ds.(i).(j) <- 0; Queue.push (i, j) q); a
let ans = ref 0
let _ =
  while not @@ Queue.is_empty q do
    let y0, x0 = Queue.pop q in
    let f (dy, dx) =
      let y, x = y0 + dy, x0 + dx in
      if 0 <= y && y < h && 0 <= x && x < w && ds.(y).(x) = -1 then
        (ans := ds.(y0).(x0) + 1; ds.(y).(x) <- !ans; Queue.push (y, x) q) in
    List.iter f [-1, 0; 0, -1; 1, 0; 0, 1]
  done;
  Printf.printf "%d\n" !ans
