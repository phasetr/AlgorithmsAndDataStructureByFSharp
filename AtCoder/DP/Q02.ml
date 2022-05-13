(*https://atcoder.jp/contests/dp/submissions/20801148*)
open Core_kernel
open Stdio

module type Monoid = sig
  type t
  val e : t
  val op: t -> t -> t
end

module type SegTree = sig
  type t
  type elt
  val init: int -> t
  val of_list: elt list -> t
  val update: t -> int -> elt -> unit
  val query: t -> int -> int -> elt
end

module SegTree(M: Monoid): SegTree with type elt := M.t = struct
  type t = { depth: int; width: int ; tree: M.t array }

  let parent i = i lsr 1
  let left i = i lsl 1
  let right i = i lsl 1 + 1

  let of_list (l: M.t list) =
    let size = List.length l in
    let depth = Int.ceil_log2 size in
    let width = Int.pow 2 depth in
    let tree = Array.create ~len:(2 * width) M.e in
    List.iteri l ~f:(fun i v -> tree.(i + width) <- v);
    for i = width - 1 downto 1 do
      tree.(i) <- M.op tree.(left i) tree.(right i)
    done;
    {depth; width; tree}

  let init n = of_list (List.init n ~f:(fun _ -> M.e))

  let update (t: t) (i:int) (v:M.t): unit =
    let i = i + (1 lsl t.depth) in
    t.tree.(i) <- v;
    let rec loop i =
      if i > 1 then
        let pi = parent i in
        t.tree.(pi) <- M.op t.tree.(left pi) t.tree.(right pi);
        loop pi
    in
    loop i

  let query (t: t) (a: int) (b: int) =
    let rec query_aux i l r =
      if (r <= a || b <= l) then M.e
      else if (a <= l && r <= b) then t.tree.(i)
      else
        let mid = (l + r) / 2 in
        let vl = query_aux (left i) l mid in
        let vr = query_aux (right i) mid r in
        M.op vl vr
    in
    query_aux 1 0 t.width
end
module RMQ = SegTree(struct
    type t = int
    let e = 0
    let op = Int.max
  end)

let () =
  let n = Caml.read_int () in
  let h = Caml.read_line () |> String.split ~on:' ' |> List.map ~f:Int.of_string |> Array.of_list in
  let a = Caml.read_line () |> String.split ~on:' ' |> List.map ~f:Int.of_string |> Array.of_list in
  let dp = RMQ.init (n + 1) in
  for i = 0 to n - 1 do
    let k = h.(i) in
    let m = RMQ.query dp 0 k in
    let cur = RMQ.query dp k (k + 1) in
    if cur < m + a.(i) then
      RMQ.update dp k (m + a.(i))
  done;
  RMQ.query dp 0 (n + 1) |> printf "%d\n"
