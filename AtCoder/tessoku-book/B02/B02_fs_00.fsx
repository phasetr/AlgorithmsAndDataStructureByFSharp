#r "nuget: FsUnit"
open FsUnit

let divisor n = [|1L..n|] |> Array.filter (fun i -> n%i=0L)
let div100 = divisor 100
(*
let A,B = 5,20
let A,B = 6,9
*)
let solve A B =
  let div100 = [|1;2;4;5;10;20;25;50;100|]
  [|A..B|]
  |> Array.filter (fun x -> div100 |> Array.contains x)
  |> fun x -> if x.Length=0 then "No" else "Yes"
let A,B = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
solve A B |> stdout.WriteLine

solve 5 20 |> should equal "Yes"
solve 6 9 |> should equal "No"
