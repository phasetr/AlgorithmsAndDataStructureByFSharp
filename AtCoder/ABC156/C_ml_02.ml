(* https://atcoder.jp/contests/abc156/submissions/14059596 *)
let () =
  Scanf.scanf "%d\n" @@ fun n ->
  let xrr = Array.init n @@ fun _ -> Scanf.scanf "%d " @@ fun d -> d in
  let p = (Array.fold_left (+) 0 xrr) / n in
  Printf.printf "%d\n" (min
    (Array.fold_left (fun sum x -> sum + (x-p) * (x-p)) 0 xrr)
    (Array.fold_left (fun sum x -> sum + (x-p-1) * (x-p-1)) 0 xrr))
