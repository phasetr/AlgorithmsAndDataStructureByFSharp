#r "nuget: FsUnit"
open FsUnit

let solve Qs =
  let rec frec stk ps qs =
    if List.isEmpty qs then (List.rev stk, List.rev ps)
    else
      match List.head qs with
        | [|0;x|] -> frec (x::stk) ps (List.tail qs)
        | [|1;x|] -> frec stk (stk.[stk.Length - x - 1]::ps) (List.tail qs)
        | [|2|]   -> frec (List.tail stk) ps (List.tail qs)
        | _ -> failwith "not come here"
  frec [] [] Qs

let Q = stdin.ReadLine() |> int
let Qs = [ for i in 1..Q do (stdin.ReadLine().Split() |> Array.map int) ]
solve Q Qs |> fst |> List.map string |> String.concat "\n" |> stdout.WriteLine

let Qs = [[|0;1|];[|0;2|];[|0;3|];[|2|];[|0;4|];[|1;0|];[|1;1|];[|1;2|]]
solve Qs |> should equal ([1;2;4],[1;2;4])
