#r "nuget: FsUnit"
open FsUnit

(*
let N,W,Ia = 4,7,[|(3,13);(3,17);(5,29);(1,10)|]
let N,W,Ia = 3,100,[|(55,2);(75,3);(40,2)|]
let N,W,Ia = 10,1000000000,[|(80000000,99);(11000000,119);(12000000,150);(15000000,174);(16000000,168);(18000000,190);(19000000,187);(25000000,273);(28000000,307);(30000000,319)|]
*)
let solve N W Ia =
  Array2D.create (N+1) 100_001 (System.Int32.MaxValue/2)
  |> fun dp ->
    dp.[0,0] <- 0
    Ia |> Array.iteri (fun i (w,v) ->
      for j in 0..100000 do dp.[i+1,j] <- if j<v then dp.[i,j] else min dp.[i,j] (dp.[i,j-v]+w))
    dp.[N,*]
  |> fun dp ->
    ((0,0),dp) ||> Array.fold (fun (i,acc) dpi -> (i+1, if dpi<=W then i else acc)) |> snd
let N,W = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Ia = Array.init N (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1])
solve N W Ia |> stdout.WriteLine

solve 4 7 [|(3,13);(3,17);(5,29);(1,10)|] |> should equal 40
solve 3 100 [|(55,2);(75,3);(40,2)|] |> should equal 4
solve 10 1000000000 [|(80000000,99);(11000000,119);(12000000,150);(15000000,174);(16000000,168);(18000000,190);(19000000,187);(25000000,273);(28000000,307);(30000000,319)|] |> should equal 1986
