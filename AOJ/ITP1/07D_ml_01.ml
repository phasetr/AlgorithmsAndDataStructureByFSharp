(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_7_D/review/1879488/superluminalsloth/OCaml *)
let split = Str.split (Str.regexp_string " ");;
let tuple3 l = let nth i = List.nth l i |> int_of_string in
               (nth 0, nth 1, nth 2);;
let rec readMtx mtx = function
  |  0 -> Array.of_list (List.rev mtx)
  | i -> let a = read_line () |> split |> List.map int_of_string |> Array.of_list
         in readMtx (a::mtx) (i-1);;

let () =
  let (n,m,l) = read_line () |> split |> tuple3 in
  let nm = readMtx [] n and
      ml = readMtx [] m and
      nl = Array.init n (fun x -> (Array.init l (fun y->0))) in
  for i = 0 to n-1 do
    for j = 0 to l-1 do
      for k = 0 to m-1 do
        nl.(i).(j) <- nl.(i).(j) + (nm.(i).(k) * ml.(k).(j))
      done
    done
  done;
  Array.iter (fun x ->
      Array.fold_left (fun x y -> x^" "^(string_of_int y)) "" x|> String.trim |> print_endline) nl;;
