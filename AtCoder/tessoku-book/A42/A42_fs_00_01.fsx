#r "nuget: FsUnit"
open FsUnit

(*
let N,K,Ia = 4,30,[|(20,30);(10,40);(50,10);(30,60)|]
*)
let solve N K (Ia:(int*int)[]) =
  let M = 100
  (0,Array.allPairs [|0..M|] [|0..M|])
  ||> Array.fold (fun acc (i,j) ->
    Ia |> Array.sumBy (fun (a,b) -> if i<=a && a<=i+K && j<=b && b<=j+K then 1 else 0)
    |> max acc)

let N,K = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Ia = Array.init N (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1])
solve N K Ia |> stdout.WriteLine

solve 4 30 [|(20,30);(10,40);(50,10);(30,60)|] |> should equal 3
solve 1 42 [|(31,41)|] |> should equal 1
solve 2 10 [|(5,5);(15,16)|] |> should equal 1
solve 2 10 [|(5,15);(15,5)|] |> should equal 2
