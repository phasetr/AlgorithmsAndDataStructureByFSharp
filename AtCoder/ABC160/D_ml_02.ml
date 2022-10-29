(* https://atcoder.jp/contests/abc160/submissions/11298838 *)
Scanf.scanf "%d %d %d"
  (fun n x y ->
    let x = x - 1 in
    let y = y - 1 in
    let warp = y - x - 1 in
    let k = Array.make n 0 in
    for st = 0 to n - 2 do
      for en = st + 1 to n - 1 do
        let dist =
          if st <= x then (
            if en <= x then en - st else
              if en >= y then en - st -  warp else
                min (en - st) ((y - warp - st) + (y - en))
          ) else if st >= y then en - st
          else (
            if en >= y then
              min (en - st) (1 + (st - x) + (en - y))
            else
              min (en - st) (1 + (st - x) + (y - en))
          )
        in
        k.(dist) <- k.(dist) + 1
      done
    done;
    for i = 1 to n - 1 do
      Printf.printf "%d\n" k.(i)
    done
  )
