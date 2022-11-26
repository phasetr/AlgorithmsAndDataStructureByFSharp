#r "nuget: FsUnit"
open FsUnit

let N = 575
let N = 3600
let solve N =
  let len = N |> string|> Seq.length
  let rec frec l acc =
    if l >= len then acc
    else acc @ (acc |> List.collect (fun s -> ["3"+s;"5"+s;"7"+s])) |> List.distinct |> frec (l+1)
  frec 0 [""]
  |> List.filter (fun s -> ['3';'5';'7'] |> List.forall (fun c -> s.Contains c) |> fun b -> b && (int s <= N))
  |> List.length

let N = stdin.ReadLine() |> int
solve N |> stdout.WriteLine

solve 575 |> should equal 4
solve 3600 |> should equal 13
solve 999999999 |> should equal 26484
