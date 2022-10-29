(* https://atcoder.jp/contests/abc125/submissions/5169276 *)
open Printf open Scanf
open Array

let () =
  scanf " %d" @@
    fun n ->
    let a = init n (fun _ -> scanf " %d" @@ fun v -> v) in
    let nn = map (fun v -> if v < 0 then 1 else 0) a
             |> fold_left (+) 0 in
    let aa =
      map abs a in
    let res = if nn mod 2 = 0 then (
                fold_left (+) 0 aa
              ) else (
                let mn = fold_left min max_int aa in
                fold_left (+) 0 aa - 2 * mn
              ) in
    print_int res
