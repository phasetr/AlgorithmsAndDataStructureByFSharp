(* https://atcoder.jp/contests/abc138/submissions/6992962 *)
let () = Scanf.scanf "%d %d\n" @@ fun n q ->
  let es = Array.make n [] in
  for i = 0 to n - 2 do
    Scanf.scanf "%d %d\n" @@ fun a b ->
      es.(a - 1) <- b - 1 :: es.(a - 1);
      es.(b - 1) <- a - 1 :: es.(b - 1)
  done;
  let acc = Array.make n 0 in
  for i = 0 to q - 1 do
    Scanf.scanf "%d %d\n" @@ fun p x ->
      acc.(p - 1) <- acc.(p - 1) + x
  done;
  let visited = Array.make n false in
  let rec visit prev v =
    if not visited.(v) then begin
      visited.(v) <- true;
      acc.(v) <- acc.(v) + prev;
      List.iter (visit acc.(v)) es.(v)
    end in
  visit 0 0;
  Array.iter (Printf.printf "%d ") acc;
  print_newline ()
