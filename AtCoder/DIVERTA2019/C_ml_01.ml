(* https://atcoder.jp/contests/diverta2019/submissions/5396334 *)
let acc_ab n s =
  snd @@ Array.fold_left (fun (c, n) c' ->
    (c', n + if c = 'A' && c' = 'B' then 1 else 0)) ('_', n) @@
  Array.init (String.length s) (String.get s)

let () = Scanf.scanf "%d\n" @@ fun n ->
  let ss = Array.init n @@ fun _ -> Scanf.scanf "%s\n" @@ fun s -> s in
  let (a, b, ba) =
    Array.fold_left (fun (a, b, ba) s ->
      if s.[0] = 'B' && s.[String.length s - 1] = 'A' then (a, b, ba + 1)
      else if s.[0] = 'B' then (a, b + 1, ba)
      else if s.[String.length s - 1] = 'A' then (a + 1, b, ba)
      else (a, b, ba)) (0, 0, 0) ss in
  Printf.printf "%d\n" @@
  Array.fold_left acc_ab 0 ss +
  if a <= 0 && b <= 0 then max 0 (ba - 1) else ba + min a b
