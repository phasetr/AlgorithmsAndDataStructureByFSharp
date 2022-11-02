(* https://atcoder.jp/contests/abc049/submissions/2593564 *)
let list_of_str s = let rec f i = if i >= String.length s then [] else s.[i] :: f (i+1) in f 0
let rec solve = function
  | [] -> "YES"
  | ('r'::'e'::('m'::'a'::'e'::'r'::'d'::xs | 's'::'a'::'r'::'e'::xs))
  | ('m'::'a'::'e'::'r'::'d'::xs) | ('e'::'s'::'a'::'r'::'e'::xs)  -> solve xs
  | _ -> "NO"
let () = Scanf.scanf "%s" list_of_str |> List.rev |> solve |> print_endline
