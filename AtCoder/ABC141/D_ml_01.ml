(* https://atcoder.jp/contests/abc141/submissions/7573653 *)
module M = Map.Make (struct
  type t = int
  let compare = compare
end)
let n, m = Scanf.scanf " %d %d" @@ fun a b -> a, b
let a_s = Array.init n @@ fun _ -> Scanf.scanf " %d" (+) 0
let im = ref M.empty
let g a = im := M.add a (1 + try M.find a !im with _ -> 0) !im
let h a = im := match M.find a !im with 1 -> M.remove a !im | c -> M.add a (c - 1) !im
let rec f i = if i >= m then M.fold (fun a c s -> s + a * c) !im 0
              else let a, _ = M.max_binding !im in g @@ a / 2; h a; f @@ i + 1
let _ = Array.iter g a_s; Printf.printf "%d\n" @@ f 0
