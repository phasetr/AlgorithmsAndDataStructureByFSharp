(* https://atcoder.jp/contests/abc069/submissions/2906098 *)
let () =
  Scanf.scanf "%d %d %d" @@ fun h w n ->
  let a =
    Array.init n (fun i ->
      Scanf.scanf " %d" (fun x -> Array.make x (i+1)))
    |> Array.to_list |> Array.concat
  in
  for i = 0 to h*w-1 do
    a.(i/w*w + if i/w mod 2 = 0 then i mod w else w-1 - i mod w)
    |> Printf.printf "%d ";
    if i mod w = w-1 then print_newline ();
  done;
