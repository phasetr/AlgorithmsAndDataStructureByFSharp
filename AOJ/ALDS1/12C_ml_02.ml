(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_12_C/review/2446599/r6eve/OCaml *)
module MakeBinaryHeap (M : sig type t val compare : t -> t -> int end) = struct
  type t = { node : M.t array; mutable size : int }
  let make n (init : M.t) = { node = Array.make n init; size = 0 }
  let empty_p t = if t.size = 0 then true else false
  let pop t =
    let rec max_heapify i =
      let l = 2*i in
      let r = 2*i + 1 in
      let m = if l <= t.size && M.compare t.node.(l) t.node.(i) > 0 then l else i in
      let m = if r <= t.size && M.compare t.node.(r) t.node.(m) > 0 then r else m in
      if m = i then ()
      else begin
          let tmp = t.node.(i) in
          t.node.(i) <- t.node.(m);
          t.node.(m) <- tmp;
          max_heapify m
        end in
    let ret = t.node.(1) in
    t.node.(1) <- t.node.(t.size);
    t.size <- t.size - 1;
    max_heapify 1;
    ret
  let push x t =
    let parent i = int_of_float (floor (float_of_int i) /. 2.) in
    let rec doit i =
      let p = parent i in
      if i <= 1 || M.compare t.node.(p) t.node.(i) >= 0 then ()
      else begin
          let tmp = t.node.(i) in
          t.node.(i) <- t.node.(p);
          t.node.(p) <- tmp;
          doit p
        end in
    t.size <- t.size + 1;
    t.node.(t.size) <- x;
    doit t.size
end

module H = MakeBinaryHeap(struct type t = (int * int) let compare x y = snd x - snd y end)
let dijkstra g n =
  let h = H.make 100000 (0, 0) in
  let d = Array.make n max_int in
  let b = Array.make n false in
  d.(0) <- 0;
  b.(0) <- true;
  H.push (0, 0) h;
  while not (H.empty_p h) do
    let (u, x) = H.pop h in
    b.(u) <- true;
    if d.(u) < -x then ()
    else
      List.iter (fun (v, c) ->
          if not b.(v) && d.(v) > d.(u) + c then begin
              d.(v) <- d.(u) + c;
              H.push (v, (-d.(v))) h;
            end) g.(u);
  done;
  d

let rec make_pair acc = function
  | [] -> acc
  | v :: c :: tl -> make_pair ((v, c) :: acc) tl
  | _ -> assert false

let make_pair lst = make_pair [] lst

let split_on_char sep s =
  let open String in
  let r = ref [] in
  let j = ref (length s) in
  for i = length s - 1 downto 0 do
    if get s i = sep then begin
        r := sub s (i + 1) (!j - i - 1) :: !r;
        j := i
      end
  done;
  sub s 0 !j :: !r

let () =
  let n = read_int () in
  let g = Array.make n [] in
  for _ = 0 to n - 1 do
    match read_line () |> split_on_char ' ' |> List.map int_of_string with
    | u :: _ :: l -> g.(u) <- make_pair l
    | _ -> assert false
  done;
  dijkstra g n |> Array.iteri (fun i e -> Printf.printf "%d %d\n" i e)
