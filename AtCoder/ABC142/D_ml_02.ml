(* https://atcoder.jp/contests/abc142/submissions/15129510 *)
let a, b = Scanf.sscanf (read_line ()) "%d %d" @@ fun a b -> (a, b)

let rec primes acc i = function
  | 0 | 1 -> acc
  | n ->
    let rec f i j = if i mod j = 0 then f (i / j) j else i in
    if i * i > n then if n = 1 then acc else n :: acc
    else if n mod i = 0 then primes (i :: acc) (i + 1) (f n i)
    else primes acc (i + 1) n

let () = primes [] 2 a
  |> List.filter (fun i -> a mod i = 0 && b mod i = 0)
  |> List.length |> ((+) 1)
  |> Printf.printf "%d\n"
