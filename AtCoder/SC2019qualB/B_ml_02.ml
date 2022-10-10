(* https://atcoder.jp/contests/jsc2019-qual/submissions/13480066 *)
let m_1e9 = int_of_float 1e9 + 7
let ( +^ ) x y = (x + y) mod m_1e9
let ( -^ ) x y = x - y + if x < y then m_1e9 else 0
let ( *^ ) x y = ((x mod m_1e9) * (y mod m_1e9)) mod m_1e9

let split_string ?(pattern="") = Str.split @@ Str.regexp pattern

let (n, k) = Scanf.sscanf (read_line ()) "%d %d" @@ fun n k -> (n, k)
let a = read_line () |> split_string ~pattern:" " |> List.map int_of_string |> Array.of_list

let l = if k mod 2 = 0 then (k / 2) *^ (k - 1) else k *^ ((k - 1) / 2)

let b = Array.fold_left (+) 0 @@ Array.init n (fun i ->
  let cnt = ref 0 in
  for j = i + 1 to n - 1 do
    if a.(i) > a.(j) then cnt := !cnt + 1
  done;
  !cnt
)

let c = Array.fold_left (+) 0 @@ Array.init n (fun i ->
  let cnt = ref 0 in
  for j = 0 to n - 1 do
    if a.(i) > a.(j) then cnt := !cnt + 1
  done;
  !cnt
)

let () = Printf.printf "%d\n" @@ b *^ k +^ c *^ l
