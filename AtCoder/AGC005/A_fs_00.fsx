#r "nuget: FsUnit"
open FsUnit

let X = "TSTTSS"
let solve X =
  let rec frec acc = function
    | [] -> acc |> List.rev
    | x::xs ->
      if x='S' then frec (x::acc) xs
      else if x='T' && (List.isEmpty acc || List.head acc='T') then frec (x::acc) xs
      else frec (List.tail acc) xs
  X |> Seq.toList |> frec [] |> List.length

let X = stdin.ReadLine()
solve X |> stdout.WriteLine

solve "TSTTSS" |> should equal 4
solve "SSTTST" |> should equal 0
solve "TSSTTTSS" |> should equal 4
