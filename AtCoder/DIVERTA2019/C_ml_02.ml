(* https://atcoder.jp/contests/diverta2019/submissions/6109720 *)
let n = Scanf.scanf " %d" @@ (+) 0
let ss = Array.init n @@ fun _ -> Scanf.scanf " %s" @@ fun s -> s
let substr_count sub s =
  let rec loop acc i r n m =
    if i >= n then acc
    else try let j = Str.search_forward r s i + m in loop (acc + 1) j r n m with _ -> acc
  in loop 0 0 (Str.regexp sub) (String.length s) (String.length sub)
let b_a = Array.fold_left (fun acc s -> acc + if s.[0] = 'B' && s.[String.length s - 1] = 'A' then 1 else 0) 0 ss
let x_a = Array.fold_left (fun acc s -> acc + if s.[0] <> 'B' && s.[String.length s - 1] = 'A' then 1 else 0) 0 ss
let b_x = Array.fold_left (fun acc s -> acc + if s.[0] = 'B' && s.[String.length s - 1] <> 'A' then 1 else 0) 0 ss
let ab = Array.fold_left (fun acc s -> acc + substr_count "AB" s) 0 ss
let _ = Printf.printf "%d\n" @@ ab + min x_a b_x + if max x_a b_x = 0 then max 0 @@ b_a - 1 else b_a
