(*https://atcoder.jp/contests/dp/submissions/20822591*)
open Core_kernel
open Stdio

module ModInt = struct
  let p = 1_000_000_007
  let (+) x y = (x + y) mod p
  let ( * ) x y = (x * y) mod p
  let (-) x y = (x - y + p) mod p
  let rec (^) x n =
    if n = 0 then 1
    else if (n mod 2) = 1 then x * (x ^ Int.(n - 1))
    else let h = x ^ (n / 2) in h * h
end

let memoize3 ~(dimx: int) ~(dimy: int) ~(f: (int -> int -> int -> 'a) -> int -> int -> int -> 'a) : int -> int -> int -> 'a =
  let memo = Array.make_matrix ~dimx ~dimy None in
  let rec g n m o =
    match memo.(n).(m) with
      Some x  -> x
    | None ->
      let result = f g n m o in
      memo.(n).(m) <- Some result;
      result
  in
  g

let () =
  let n = Caml.read_int () in
  let g = Array.create ~len:n [] in
  for _ = 0 to n - 2 do
    let x, y = Scanf.sscanf (Caml.read_line ()) "%d %d" (fun x y -> (x - 1, y - 1)) in
    g.(x) <- y::g.(x);
    g.(y) <- x::g.(y)
  done;
  let open ModInt in
  let f_norec f v v_color parent =
    g.(v)
    |> List.filter_map ~f:(fun nv ->
        if nv = parent then None
        else begin
          match v_color with
            0 -> Some (f nv 0 v + f nv 1 v)
          | 1 -> Some (f nv 0 v)
          | _ -> assert false
        end
      )
    |> List.fold ~init:1 ~f:(fun x y -> x * y)
  in
  let f = memoize3 ~dimx:n ~dimy:2 ~f:f_norec in
  f 0 0 0 + f 0 1 0 |> printf "%d\n"

