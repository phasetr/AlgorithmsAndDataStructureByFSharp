let solve r =
  let pi = 4.0 *. atan 1.0 in
  Printf.sprintf "%f %f\n" (pi *. r *. r) (2.0 *. pi *. r);;
let () = read_float() |> solve |> print_endline;;

solve 2.0;; (* "12.566371 12.566371\n" *)
solve 3.0;; (* "28.274334 18.849556\n" *)
