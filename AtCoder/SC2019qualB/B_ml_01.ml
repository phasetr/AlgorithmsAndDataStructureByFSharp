(* https://atcoder.jp/contests/jsc2019-qual/submissions/7137637 *)
let n, k = Scanf.scanf " %d %d" @@ fun a b -> a, b
let a_s = Array.init n @@ fun _ -> Scanf.scanf " %d" (+) 0
let x = ref 0
let y = for i = 0 to n - 2 do for j = i + 1 to n - 1 do if a_s.(i) > a_s.(j) then incr x done done;
  Array.fold_left (fun c a0 -> Array.fold_left (fun c a -> if a0 > a then c + 1 else c) c a_s) 0 a_s
let c = k * (k - 1) / 2 mod 1000000007
let f g a b = g a b mod 1000000007
let ( * ) = f ( * )
let (+) = f (+)
let _ = !x * k + c * y |> Printf.printf "%d\n"
