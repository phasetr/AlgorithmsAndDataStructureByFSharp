#r "nuget: FsUnit"
open FsUnit

(*
let N,Ia = 3,[|(1,2,2);(2,3,1)|]
let N,Ia = 5,[|(2,5,2);(2,3,10);(1,3,8);(3,4,2)|]
*)
let solve N Ia =
  let odd x = x%2=1
  let Aa =
    (Array.init N (fun _ -> ResizeArray<int*bool>()),Ia)
    ||> Array.fold (fun Aa (u,v,w) ->
      Aa.[u-1].Add((v-1,odd w)); Aa.[v-1].Add((u-1,odd w)); Aa)
    |> Array.map (fun v -> v.ToArray())

  let rec dfs p i o Xa =
    Array.set Xa i (if o then 1 else 0)
    Array.get Aa i
    |> Array.filter (fun (i,_) -> i <> p)
    |> Array.fold (fun acc (j,wParity) -> dfs i j (o<>wParity) acc) Xa
  Array.zeroCreate N |> dfs 0 0 false

let N = stdin.ReadLine() |> int
let Ia = Array.init (N-1) (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1],x.[2])
solve N Ia |> Array.iter stdout.WriteLine

solve 3 [|(1,2,2);(2,3,1)|]
// [|0;0;1|]
solve 5 [|(2,5,2);(2,3,10);(1,3,8);(3,4,2)|]
// [|1;0;1;0;1|]
