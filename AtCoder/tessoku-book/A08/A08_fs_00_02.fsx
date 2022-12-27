#r "nuget: FsUnit"
open FsUnit

(*
let H,W,Xa,Q,Qa = 5,5,[|[|2;0;0;5;1|];[|1;0;3;0;0|];[|0;8;5;0;2|];[|4;1;0;0;6|];[|0;9;2;7;0|]|],2,[|(2,2,4,5);(1,1,5,5)|]
*)
let solve H W (Xa:int[][]) Q Qa =
  let Sa =
    Xa
    |> Array.map (Array.scan (+) 0)
    |> Array.scan (Array.map2 (+)) (Array.create (W+1) 0)
  Qa |> Array.map (fun (a,b,c,d) -> Sa.[c].[d] - Sa.[c].[b-1] - Sa.[a-1].[d] + Sa.[a-1].[b-1])

let H,W = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Xa = Array.init H (fun _ -> stdin.ReadLine().Split() |> Array.map int)
let Q = stdin.ReadLine() |> int
let Qa = Array.init Q (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1],x.[2],x.[3])
solve H W Xa Q Qa |> Array.iter stdout.WriteLine

solve 5 5 [|[|2;0;0;5;1|];[|1;0;3;0;0|];[|0;8;5;0;2|];[|4;1;0;0;6|];[|0;9;2;7;0|]|] 2 [|(2,2,4,5);(1,1,5,5)|] |> should equal [|25;56|]
(*
5 5
2 0 0 5 1
1 0 3 0 0
0 8 5 0 2
4 1 0 0 6
0 9 2 7 0
2
2 2 4 5
1 1 5 5
*)

@"記事作成用コード"
Xa
|> Array.map (Array.scan (+) 0)
|> Array.scan (fun xa ya ->
   printfn "%A" (xa,ya)
   Array.map2 (+) xa ya) (Array.create (W+1) 0)
