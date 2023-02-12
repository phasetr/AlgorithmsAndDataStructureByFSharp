#r "nuget: FsUnit"
open FsUnit

(*
let N,W,Ia = 4,7,[|(3,13);(3,17);(5,29);(1,10)|]
let N,W,Ia = 3,100,[|(55,2);(75,3);(40,2)|]
let N,W,Ia = 10,1000000000,[|(80000000,99);(11000000,119);(12000000,150);(15000000,174);(16000000,168);(18000000,190);(19000000,187);(25000000,273);(28000000,307);(30000000,319)|]
*)
let solve N W Ia =
  Array.create 100_001 (W+1)
  |> fun dp ->
    dp.[0] <- 0
    (dp, Ia) ||> Array.fold (fun dp (w,v) ->
      for v0 in 100_000..(-1)..v do dp.[v0] <- min dp.[v0] (dp.[v0-v]+w)
      dp)
  |> Array.indexed |> Array.filter (fun (i,x) -> x<=W) |> Array.last |> fst
let N,W = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Ia = Array.init N (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1])
solve N W Ia |> stdout.WriteLine

solve 4 7 [|(3,13);(3,17);(5,29);(1,10)|] |> should equal 40
solve 3 100 [|(55,2);(75,3);(40,2)|] |> should equal 4
solve 10 1000000000 [|(80000000,99);(11000000,119);(12000000,150);(15000000,174);(16000000,168);(18000000,190);(19000000,187);(25000000,273);(28000000,307);(30000000,319)|] |> should equal 1986
