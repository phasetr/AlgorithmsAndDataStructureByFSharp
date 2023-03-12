#r "nuget: FsUnit"
open FsUnit

(*
let N,M,K,Ia = 6,4,3,[|(3,4);(3,5);(2,5);(1,6)|]
let N,M,K,Ia = 4,6,1,[|(1,2);(1,3);(1,4);(2,3);(2,4);(3,4)|]
let N,M,K,Ia = 10,4,10,[|(1,3);(2,4);(2,3);(1,4)|]
*)
let solve N M K Ia =
  let scores =
    (Array2D.create (N+1) (N+1) 0, Ia)
    ||> Array.fold (fun sa (a,b) ->
      for i in 1..a do for j in b..N do sa.[i,j] <- sa.[i,j]+1
      sa)
  Array2D.create (K+1) (N+1) (System.Int32.MinValue)
  |> fun dp ->
    dp.[0,0] <- 0
    for k in 1..K do
      for i in 1..N do
        for j in 1..i do
          dp.[k,i] <- max dp.[k,i] (dp.[k-1,j-1] + scores.[j,i])
    dp.[K,N]

let N,M,K = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1],x.[2])
let Ia = Array.init M (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1])
solve N M K Ia |> stdout.WriteLine

solve 6 4 3 [|(3,4);(3,5);(2,5);(1,6)|] |> should equal 3
solve 4 6 1 [|(1,2);(1,3);(1,4);(2,3);(2,4);(3,4)|] |> should equal 6
solve 10 4 10 [|(1,3);(2,4);(2,3);(1,4)|] |> should equal 0
