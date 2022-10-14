(* https://atcoder.jp/contests/abc076/submissions/2821226 *)
open String
let rec iter a b f = if a >= b then [] else let v = f a in v :: iter (a+1) b f
let check a b =
  iter 0 (length a) (fun i -> a.[i] = '?' || a.[i] = b.[i])
  |> List.fold_left (&&) true
let () =
  Scanf.scanf "%s %s" @@ fun s' t ->
  let s'_len, t_len = length s', length t in
  iter 0 (s'_len-t_len+1) (fun i ->
    if check (sub s' i t_len) t then
      sub s' 0 i ^ t ^ sub s' (i+t_len) (s'_len-i-t_len)
      |> map (function '?' -> 'a' | c -> c)
      |> fun s -> Some s
    else
      None)
  |> List.fold_left (fun r -> function None -> r | Some s -> s) "UNRESTORABLE"
  |> print_endline
