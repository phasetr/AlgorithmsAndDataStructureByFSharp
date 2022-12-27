#r "nuget: FsUnit"
open FsUnit

(*
let H,W,Xa,Q,Qa = 5,5,[|[|2;0;0;5;1|];[|1;0;3;0;0|];[|0;8;5;0;2|];[|4;1;0;0;6|];[|0;9;2;7;0|]|],2,[|(2,2,4,5);(1,1,5,5)|]
*)
let solve H W (Xa:int[][]) Q Qa =
  let Sa =
    let sa = Array2D.create (H+1) (W+1) 0
    let Ia = [| for i in 0..H-1 do for j in 0..W-1 do (i,j) |]
    Ia |> Array.iter (fun (i,j) -> sa.[i+1,j+1] <- sa.[i+1,j]+Xa.[i].[j])
    Ia |> Array.iter (fun (i,j) -> sa.[i+1,j+1] <- sa.[i+1,j+1]+sa.[i,j+1])
    sa
  Qa |> Array.map (fun (a,b,c,d) -> Sa.[c,d] - Sa.[c,b-1] - Sa.[a-1,d] + Sa.[a-1,b-1])

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
