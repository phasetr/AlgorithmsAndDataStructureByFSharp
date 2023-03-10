#r "nuget: FsUnit"
open FsUnit

(*
let N = 5
*)
let solve N =
  System.Convert.ToString(N-1,2)
  |> int64
  |> sprintf "%010i"
  |> String.map (fun c -> if c='0' then '4' else '7')
let N = stdin.ReadLine() |> int
solve N |> stdout.WriteLine

solve 5 |> should equal "4444444744"
