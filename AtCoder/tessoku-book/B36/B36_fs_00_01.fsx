#r "nuget: FsUnit"
open FsUnit

(*
let N,K,S = 7,3,"1010111"
let N,K,S = 10,6,"0001010001"
let N,K,S = 2,2,"11"
*)
let solve N K S =
  S |> Seq.sumBy (fun c -> if c='1' then 1 else 0)
  |> fun s -> if s%2=K%2 then "Yes" else "No"
let N,K = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let S = stdin.ReadLine()
solve N K S |> stdout.WriteLine

solve 7 3 "1010111" |> should equal "Yes"
solve 10 6 "0001010001" |> should equal "No"
solve 2 2 "11" |> should equal "Yes"
