(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_14_B/review/2472404/rabbisland/OCaml *)
let prk ss ps f =
  let ssl = String.length ss in
  let psl = String.length ps in
  let b = 10007 in
  let rec pow n =
    if n = 0 then 1
    else if n mod 2 = 0 then let x = pow (n / 2) in x * x
    else b * pow (n-1) in
  let bb = pow psl in
  let rh s =
    let h = ref 0 in
    String.iter (fun c -> h := !h * b + (Char.code c)) s; !h
  in
  let ih = rh (String.sub ss 0 psl) in
  let psh = rh ps in
  let rec loop h x =
    if h = psh then f x;
    if x >= ssl - psl then ()
    else
      let nh = h * b + (Char.code ss.[x+psl]) - (Char.code ss.[x]) * bb in
      loop nh (x+1)
  in
  loop ih 0

let () =
  let t = read_line () in
  let p = read_line () in
  let f x = string_of_int x |> print_endline in
  try prk t p f with _ -> ()
