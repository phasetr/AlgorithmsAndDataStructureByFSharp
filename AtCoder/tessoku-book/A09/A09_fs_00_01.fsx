#r "nuget: FsUnit"
open FsUnit

let solve H W N Ia =
  (Array.init (H+1) (fun _ -> Array.create (W+1) 0), Ia)
  ||> Array.fold (fun Xa (a,b,c,d) ->
    Xa.[a-1].[b-1] <- Xa.[a-1].[b-1]+1;
    Xa.[a-1].[d] <- Xa.[a-1].[d]-1;
    Xa.[c].[b-1] <- Xa.[c].[b-1]-1;
    Xa.[c].[d] <- Xa.[c].[d]+1;
    Xa)
  |> Array.map (Array.scan (+) 0)
  |> Array.scan (Array.map2 (+)) (Array.create (W+2) 0)
  |> fun Xa -> Xa.[1..H] |> Array.map (fun Ra -> Ra.[1..W])

let H,W,N = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1],x.[2])
let Ia = Array.init N (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1],x.[2],x.[3])
solve H W N Ia |> Array.iter (Array.map string >> String.concat " " >> stdout.WriteLine)

let () =
  let H,W,N,Ia = 5,5,2,[|(1,1,3,3);(2,2,4,4)|]
  solve H W N Ia |> should equal [|[|1;1;1;0;0|];[|1;2;2;1;0|];[|1;2;2;1;0|];[|0;1;1;1;0|];[|0;0;0;0;0|]|]
  ()

(*
1 1 1 0 0
1 2 2 1 0
1 2 2 1 0
0 1 1 1 0
0 0 0 0 0
*)
