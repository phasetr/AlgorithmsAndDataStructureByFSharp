#r "nuget: FsUnit"
open FsUnit

(*
let H,W,Ia = 2,3,[|[|1;2;3|];[|0;1;1|]|]
let H,W,Ia = 3,2,[|[|1;0|];[|2;1|];[|1;0|]|]
let H,W,Ia = 1,5,[|[|9;9;9;9;9|]|]
*)
let solve H W (Ia:int[][]) =
  let Xa = ResizeArray<int*int*int*int>()
  for i in 0..H-1 do
    for j in 0..W-2 do
      if Ia.[i].[j]%2 = 1 then
        Ia.[i].[j] <- Ia.[i].[j]-1
        Ia.[i].[j+1] <- Ia.[i].[j+1]+1
        Xa.Add((i,j,i,j+1))
  for i in 0..H-2 do
    if Ia.[i].[W-1]%2 = 1 then
      Ia.[i].[W-1] <- Ia.[1].[W-1]-1
      Ia.[i+1].[W-1] <- Ia.[i+1].[W-1]+1
      Xa.Add(i,W-1,i+1,W-1)
  Xa.ToArray() |> fun Xa -> Array.append [|string Xa.Length|] (Xa |> Array.map (fun (a,b,c,d) -> sprintf "%d %d %d %d" (a+1) (b+1) (c+1) (d+1)))

let H,W = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Ia = Array.init H (fun _ -> stdin.ReadLine().Split() |> Array.map int)
solve H W Ia |> Array.iter stdout.WriteLine

solve 2 3 [|[|1;2;3|];[|0;1;1|]|]
(*
3
2 2 2 3
1 1 1 2
1 3 1 2
*)
solve 3 2 [|[|1;0|];[|2;1|];[|1;0|]|]
(*
3
1 1 1 2
1 2 2 2
3 1 3 2
*)
solve 1 5 [|[|9;9;9;9;9|]|]
(*
2
1 1 1 2
1 3 1 4
*)
