#r "nuget: FsUnit"
open FsUnit

let solve Xa =
  let f = function
    | (x::y::acc, "+") -> (y + x) :: acc
    | (x::y::acc, "-") -> (y - x) :: acc
    | (x::y::acc, "*") -> (y * x) :: acc
    | (acc, n) -> (int n) :: acc
  ([], Xa |> Array.toList) ||> List.fold (fun acc x -> f (acc,x)) |> List.head

let Xa = stdin.ReadLine().Split()
solve Xa |> stdout.WriteLine

solve [|"1";"2";"+"|] |> should equal 3
solve [|"1";"2";"+";"3";"4";"-";"*"|] |> should equal -3
