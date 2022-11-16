(* https://atcoder.jp/contests/abc151/submissions/9891265 *)
open Queue
let ans, q, h, w, ss = Scanf.(scanf "%d %d" @@ fun h w -> ref 0, create (), h, w, Array.init h @@ fun _ -> scanf " %s" @@ fun s -> s)
let f sy sx =
  let ds = Array.make_matrix h w ~-1 in
  push (sy, sx) q;
  ds.(sy).(sx) <- 0;
  while not @@ is_empty q do
    let y0, x0 = pop q in
    List.iter (fun (dy, dx) ->
        let y, x = y0 + dy, x0 + dx in
        if 0 <= y && y < h && 0 <= x && x < w && ds.(y).(x) = -1 && ss.(y).[x] = '.'
        then (push (y, x) q;
              ds.(y).(x) <- ds.(y0).(x0) + 1;
              ans := max !ans ds.(y).(x))) [-1, 0; 0, -1; 1, 0; 0, 1]
  done
let _ =
  for sy = 0 to h - 1 do
    for sx = 0 to w - 1 do
      if ss.(sy).[sx] = '.' then (f sy sx)
    done
  done;
  Printf.printf "%d\n" !ans
