#r "nuget: FsUnit"
open FsUnit

let solve N =
  let rec doit i x acc =
    if i*i > N then if x=1 then acc else x :: acc
    else if x%i = 0 then doit i (x/i) (i :: acc)
    else doit (i+1) x acc in
  doit 2 N [] |> List.rev |> fun x -> (N,x)

let N = stdin.ReadLine() |> int
solve N |> (fun (_,x) -> x |> List.map string |> String.concat " ") |> (fun s -> $"{N}: {s}") |> stdout.WriteLine

solve 12 |> should equal (12,[2;2;3])
solve 126 |> should equal (126,[2;3;3;7])
