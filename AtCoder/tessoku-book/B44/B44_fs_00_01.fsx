#r "nuget: FsUnit"
open FsUnit

(*
let N,Aa,Q,Qa = 3,[|[|1;2;3|];[|4;5;6|];[|7;8;9|]|],7,[|(2,2,1);(1,1,2);(2,2,1);(2,1,3);(1,2,3);(2,2,3);(2,3,2)|]
let N,Aa,Q,Qa = 2,[|[|8;16|];[|32;64|]|],3,[|(2,2,1);(1,1,2);(2,2,1)|]
*)
let solve N (Aa:(int[][])) Q Qa =
  (([],Array.init (N+1) id), Qa) ||> Array.fold (fun (acc, Ra) (q,x,y) ->
    if q=1 then let i,j = Ra.[x],Ra.[y] in Ra.[x] <- j; Ra.[y] <- i; acc,Ra
    else (Aa.[Ra.[x]-1].[y-1]::acc, Ra))
  |> fst |> List.rev

let N = stdin.ReadLine() |> int
let Aa = Array.init N (fun _ -> stdin.ReadLine().Split() |> Array.map int)
let Q = stdin.ReadLine() |> int
let Qa = Array.init Q (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1],x.[2])
solve N Aa Q Qa |> List.iter stdout.WriteLine

solve 3 [|[|1;2;3|];[|4;5;6|];[|7;8;9|]|] 7 [|(2,2,1);(1,1,2);(2,2,1);(2,1,3);(1,2,3);(2,2,3);(2,3,2)|] |> should equal [4;1;6;9;2]
solve 2 [|[|8;16|];[|32;64|]|] 3 [|(2,2,1);(1,1,2);(2,2,1)|] |> should equal [32;8]
