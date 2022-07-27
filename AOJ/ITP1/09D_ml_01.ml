(* https://onlinejudge.u-aizu.ac.jp/solutions/problem/ITP1_9_D/review/2032478/ydash/OCaml *)
let () =
  let print str a b = print_endline (String.sub str a (b-a+1)) in
  let replace str a b p =
    String.mapi (fun i c -> if i >= a && i <= b then p.[i-a] else c) str in
  let reverse str a b =
    String.mapi (fun i c -> if i >= a && i <= b then str.[a-i+b] else c) str in
  let rec loop acc = function
    | 0 -> ()
    | i ->
       let code = read_line () |>Str.split (Str.regexp " ") |> Array.of_list in
       let op,a,b = code.(0),
                    code.(1) |> int_of_string,
                    code.(2) |> int_of_string in
       match op with
       | "print" -> print acc a b; loop acc (i-1)
       | "reverse" -> loop (reverse acc a b) (i-1)
       | _ -> loop (replace acc a b code.(3)) (i-1) in
  let str = read_line () in
  loop str (read_int ())
