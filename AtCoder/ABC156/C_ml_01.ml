(* https://atcoder.jp/contests/abc156/submissions/19062740 *)
let solve n xs =
  let rec range m n = if m > n then [] else m :: range (m+1) n in
  let pow2 x = x * x in
  let minx = List.fold_left min max_int xs in
  let maxx = List.fold_left max min_int xs in
  let part p = List.fold_left (+) 0 (List.map (fun x -> pow2 (x - p)) xs) in
  range minx maxx |> List.map part |> List.fold_left min max_int

let () =
  let n = read_int () in
  let xs = read_line () |> String.split_on_char ' ' |> List.map int_of_string in
  Printf.printf "%d" @@ solve n xs
