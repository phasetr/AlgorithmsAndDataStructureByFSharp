#load "str.cma"
(* 2つWAあり *)
let solve sa sb sc =
  let rec frec acc sa sb sc = match acc with
    | "a" -> if List.length sa=0 then "A" else frec (List.hd sa) (List.tl sa) sb sc
    | "b" -> if List.length sb=0 then "B" else frec (List.hd sb) sb (List.tl sb) sc
    | "c" -> if List.length sc=0 then "C" else frec (List.hd sc) sa sb (List.tl sc)
    | _   -> failwith "not come here" in
  let split s = Str.split (Str.regexp "") s in
  frec "a" (split sa) (split sb) (split sc);;
let sa,sb,sc = Scanf.scanf "%s\n%s\n%s" (fun a b c -> a,b,c) in
solve sa sb sc |> print_endline;;

solve "aca" "accc" "ca" = "A";;
solve "abcb" "aacb" "bccc" = "C";;
