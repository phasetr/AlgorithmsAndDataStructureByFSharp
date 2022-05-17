(*https://atcoder.jp/contests/dp/submissions/23305240*)
open Core

let int_inf = Int.max_value
let id x = x
let get_int () = Scanf.scanf "%d " id
let n = get_int ()
let h = Array.init n ~f:(fun _ -> get_int ())

let dp_tbl =
  let tbl = Hashtbl.create (module Int) in
  Hashtbl.add_exn tbl ~key:0 ~data:0;
  Hashtbl.add_exn tbl ~key:1 ~data:(Int.abs (h.(1) - h.(0)));
  tbl
;;

let rec dp x =
  Hashtbl.find_or_add dp_tbl x ~default:(fun () ->
      Int.min
        (dp (x - 1) + Int.abs (h.(x - 1) - h.(x)))
        (dp (x - 2) + Int.abs (h.(x - 2) - h.(x))))
;;

let ans = dp (n - 1) |> Int.to_string
let () = ans |> print_endline
