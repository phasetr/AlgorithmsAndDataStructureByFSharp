#r "nuget: FsUnit"
open FsUnit

(*
let N,Ia = 3,[|(1,2,2);(2,3,1)|]
let N,Ia = 5,[|(2,5,2);(2,3,10);(1,3,8);(3,4,2)|]
*)
let solve N Ia =
  let Aa =
    (Array.init N (fun _ -> []),Ia)
    ||> Array.fold (fun Aa (u,v,w) ->
      Aa.[u-1]<-(v-1,w&&&1)::Aa.[u-1]; Aa.[v-1]<-(u-1,w&&&1)::Aa.[v-1]; Aa)

  let rec dfs pi ci v Xa =
    Array.set Xa ci (v^^^1)
    Array.get Aa ci
    |> List.filter (fun (i,_) -> i <> pi)
    |> List.fold (fun acc (gci,w) -> dfs ci gci (v^^^w) acc) Xa
  Array.zeroCreate N |> dfs 0 0 0

let N = stdin.ReadLine() |> int
let Ia = Array.init (N-1) (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1],x.[2])
solve N Ia |> Array.iter stdout.WriteLine

solve 3 [|(1,2,2);(2,3,1)|]
// [|0;0;1|]
solve 5 [|(2,5,2);(2,3,10);(1,3,8);(3,4,2)|]
// [|1;0;1;0;1|]
