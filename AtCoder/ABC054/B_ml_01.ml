(* https://atcoder.jp/contests/abc054/submissions/9279652 *)
let n, m = Scanf.sscanf (read_line ()) "%d %d" @@ fun a b -> a, b
let a_s = Array.init n @@ fun _ -> read_line ()
let bs = Array.init m @@ fun _ -> read_line ()
let _ = for i = 0 to n - m do for j = 0 to n - m do let b = ref true in
  for k = 0 to m - 1 do for l = 0 to m - 1 do if a_s.(i + k).[j + l] <> bs.(k).[l] then b := false done done; if !b then (print_endline "Yes"; exit 0) done done; print_endline "No"
