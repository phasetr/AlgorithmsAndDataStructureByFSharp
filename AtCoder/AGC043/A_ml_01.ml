(* https://atcoder.jp/contests/agc043/submissions/16243664 *)
Scanf.scanf "%d %d" (fun h w ->
    let s = Array.init h (fun _ -> Scanf.scanf " %s" (fun s -> s)) in
    let mat = Array.make_matrix h w 100000 in
    mat.(0).(0) <- if s.(0).[0] = '#' then 1 else 0;
    for y = 0 to h - 1 do
      for x = 0 to w - 1 do
        if x < w - 1 then (
          let q = if s.(y).[x] = '.' && s.(y).[x + 1] = '#' then 1 else 0 in
          mat.(y).(x + 1) <- min mat.(y).(x + 1) (mat.(y).(x) + q)
        );
        if y < h - 1 then (
          let q = if s.(y).[x] = '.' && s.(y + 1).[x] = '#' then 1 else 0 in
          mat.(y + 1).(x) <- min mat.(y + 1).(x) (mat.(y).(x) + q)
        );
      done
    done;
    Printf.printf "%d\n" mat.(h - 1).(w - 1)
  )
