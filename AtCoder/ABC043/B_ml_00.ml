#load "str.cma";;
let s = "01B0"
let solve (s: string) =
  s |> Str.split (Str.regexp "")
  |> List.fold_left
       (fun acc x ->
         if x="B" then
           match acc with
           | [] -> []
           | _::y -> y
         else x::acc) []
  |> List.rev |> String.concat "";;
read_line() |> solve |> print_endline;;

solve "01B0" = "00";;
solve "0BB1" = "1";;
