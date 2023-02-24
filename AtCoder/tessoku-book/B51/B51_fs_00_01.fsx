#r "nuget: FsUnit"
open FsUnit

(*
let S = "(())()"
*)
let solve S =
  let rec frec acc i stack = function
    | [] -> acc
    | hd::tl ->
      if hd='(' then frec acc (i+1) (i::stack) tl
      else frec (sprintf "%d %d" (List.head stack) i :: acc) (i+1) (List.tail stack) tl
  S |> Seq.toList |> frec [] 1 [] |> List.rev
let S = stdin.ReadLine()
solve S |> List.iter stdout.WriteLine

solve "(())()" |> should equal ["2 3";"1 4";"5 6"]
