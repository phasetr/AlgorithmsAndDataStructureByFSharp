#r "nuget: FsUnit"
open FsUnit

(*
let N,Aa = 9,[|10;20;30;40;50;60;70;80;90|]
*)
let solve N Aa =
  Array.create 100 0
  |> fun Ca ->
    Aa |> Array.iter (fun a -> let x = a%100 in Ca.[x] <- Ca.[x]+1)
    Ca.[0]*(Ca.[0]-1)/2 + Ca.[50]*(Ca.[50]-1)/2 + ([|1..49|] |> Array.sumBy (fun i -> Ca.[i]*Ca.[100-i]))

let N = stdin.ReadLine() |> int
let Aa = stdin.ReadLine().Split() |> Array.map int
solve N Aa |> stdout.WriteLine

solve 9 [|10;20;30;40;50;60;70;80;90|] |> should equal 4

// hand_02.txt
solve 3 [|100;100;100|] |> should equal 3
