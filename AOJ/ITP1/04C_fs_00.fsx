#r "nuget: FsUnit"
open FsUnit

let calc a b = function
  | "+" -> a+b
  | "-" -> a-b
  | "*" -> a*b
  | "/" -> a/b
  | otherwise -> failwith "do not come here"
let rec solve =
  let (a,op,b) = stdin.ReadLine().Split() |> (fun xa -> (int xa.[0], xa.[1], int xa.[2]))
  if op="?" then ()
  else
    calc a b op |> stdout.WriteLine
    solve

solve()

calc 1 2 "+" |> should equal 3
calc 56 18 "-" |> should equal 38
calc 13 2 "*" |> should equal  26
calc 100 10 "/" |> should equal 10
calc 27 81 "+" |> should equal  108
