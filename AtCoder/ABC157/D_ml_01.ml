(* https://atcoder.jp/contests/abc157/submissions/10472333 *)
Scanf.scanf "%d %d %d" (fun n m k ->
    let par = Array.init n (fun i -> i) in
    let size = Array.make n 1 in
    let near = Array.make n 0 in
    let rec root x =
      if par.(x) = x then x else
        let r = root par.(x) in
        let () = par.(x) <- r in
        r
    in
    for i = 1 to m do
      Scanf.scanf " %d %d" (fun a b ->
          let a = a - 1 in
          let b = b - 1 in
          near.(a) <- near.(a) + 1;
          near.(b) <- near.(b) + 1;
          if root a <> root b then (
            size.(par.(a)) <- size.(par.(a)) + size.(par.(b));
            par.(par.(b)) <- par.(a)
          )
        )
    done;
    for i = 1 to k do
      Scanf.scanf " %d %d" (fun c d ->
          let c = c - 1 in
          let d = d - 1 in
          if root c = root d then (
            near.(c) <- near.(c) + 1;
            near.(d) <- near.(d) + 1;
          )
        )
    done;
    for i = 0 to n - 1 do
      Printf.printf "%d " (size.(root i) - near.(i) - 1)
    done
  )
