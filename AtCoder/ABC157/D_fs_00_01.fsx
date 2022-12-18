#r "nuget: FsUnit"
open FsUnit
(*
let N,M,K,Xa,Ya = 4,4,1,[|(2,1);(1,3);(3,2);(3,4)|],[|(4,1)|]
let N,M,K,Xa,Ya = 5,10,0,[|(1,2);(1,3);(1,4);(1,5);(3,2);(2,4);(2,5);(4,3);(5,3);(4,5)|],[||]
let N,M,K,Xa,Ya = 10,9,3,[|(10,1);(6,7);(8,2);(2,5);(8,4);(7,3);(10,9);(6,4);(5,8)|],[|(2,6);(7,5);(3,1)|]
*)
let solve N M K Xa Ya =
  let friends =
    let g = Array.init N (fun _ -> ResizeArray<int>())
    Xa |> Array.iter (fun (a,b) -> g.[a-1].Add (b-1); g.[b-1].Add (a-1))
    g |> Array.map (fun a -> a.ToArray())
  let blocks = Ya |> Array.map (fun (c,d) -> (c-1,d-1))

  let (group, groupCount) =
    let visited = Array.create N false
    let group = Array.zeroCreate N

    let rec dfs root node =
      if visited.[node] then 0
      else
        visited.[node] <- true
        group.[node] <- root
        1 + (friends.[node] |> Array.sumBy (fun c -> dfs root c))

    let result = Array.init N (fun i -> dfs i i)
    let groupCount = Array.init N (fun i -> result.[group.[i]])
    (group, groupCount)

  let r = groupCount |> Array.mapi (fun i c -> c - 1 - friends.[i].Length)
  blocks |> Array.iter (fun (c, d) -> if group.[c] = group.[d] then r.[c] <- r.[c]-1; r.[d] <- r.[d]-1)
  r

let N,M,K = stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x[1],x.[2]
let Xa = Array.init M (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1])
let Ya = Array.init K (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1])
solve N M K Xa Ya |> Array.map string |> String.concat " " |> stdout.WriteLine

solve 4 4 1 [|(2,1);(1,3);(3,2);(3,4)|] [|(4,1)|] |> should equal [|0;1;0;1|]
solve 5 10 0 [|(1,2);(1,3);(1,4);(1,5);(3,2);(2,4);(2,5);(4,3);(5,3);(4,5)|] [||] |> should equal [|0;0;0;0;0|]
solve 10 9 3 [|(10,1);(6,7);(8,2);(2,5);(8,4);(7,3);(10,9);(6,4);(5,8)|] [|(2,6);(7,5);(3,1)|] |> should equal [|1;3;5;4;3;3;3;3;1;0|]
