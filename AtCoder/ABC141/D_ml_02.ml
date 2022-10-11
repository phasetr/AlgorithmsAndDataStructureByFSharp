(* https://atcoder.jp/contests/abc141/submissions/7545564 *)
module IntMap = Map.Make (struct
  type t = int
  let compare = compare
end)

let add a s = IntMap.add a (1 + try IntMap.find a s with Not_found -> 0) s

let remove a s =
  match IntMap.find a s with
  | exception Not_found -> s
  | 1 -> IntMap.remove a s
  | n -> IntMap.add a (n - 1) s

let () =
  Scanf.scanf "%d %d\n" @@
    fun n m ->
    let as_ = Array.init n @@ fun _ -> Scanf.scanf "%d " @@ fun a -> a in
    let rec solve s = function
      | 0 -> s
      | n ->
         let (a, _) = IntMap.max_binding s in
         solve (add (a / 2) (remove a s)) (n - 1) in
    Printf.printf "%d\n" @@
      IntMap.fold (fun a n acc -> acc + a * n)
        (solve (Array.fold_right add as_ IntMap.empty) m) 0
