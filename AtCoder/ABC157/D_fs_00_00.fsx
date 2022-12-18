#r "nuget: FsUnit"
open FsUnit

(*
let N,M,K,Xa,Ya = 4,4,1,[|(2,1);(1,3);(3,2);(3,4)|],[|(4,1)|]
let N,M,K,Xa,(Ya:int[]) = 5,10,0,[|(1,2);(1,3);(1,4);(1,5);(3,2);(2,4);(2,5);(4,3);(5,3);(4,5)|],[||]
let N,M,K,Xa,Ya = 10,9,3,[|(10,1);(6,7);(8,2);(2,5);(8,4);(7,3);(10,9);(6,4);(5,8)|],[|(2,6);(7,5);(3,1)|]
*)
let solve N M K Xa Ya =
  let parent = Array.init N id
  let size = Array.create N 1
  let fof = Array.create N 0

  let incFof i = Array.set fof i (fof.[i]+1)
  let rec root x =
    if parent.[x] = x then x
    else let r = root parent.[x] in parent.[x] <- r; r

  Xa |> Array.iter (fun (a0,b0) ->
    let a,b = a0-1,b0-1
    incFof a; incFof b
    if root a <> root b then
      size.[parent.[a]] <- size.[parent.[a]] + size.[parent.[b]]
      parent.[parent.[b]] <- parent.[a])

  Ya |> Array.iter (fun (c0,d0) ->
    let c,d = c0-1,d0-1
    if root c = root d then incFof c; incFof d)

  [|0..N-1|] |> Array.map (fun i -> size.[root i] - fof.[i] - 1)

let N,M,K = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1],x.[2])
let Xa = Array.init M (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1])
let Ya = Array.init K (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1])
solve Xa |> Array.map string |> String.concat " " |> stdout.WriteLine

solve 4 4 1 [|(2,1);(1,3);(3,2);(3,4)|] [|(4,1)|] |> should equal [|0;1;0;1|]
solve 5 10 0 [|(1,2);(1,3);(1,4);(1,5);(3,2);(2,4);(2,5);(4,3);(5,3);(4,5)|] [||] |> should equal [|0;0;0;0;0|]
solve 10 9 3 [|(10,1);(6,7);(8,2);(2,5);(8,4);(7,3);(10,9);(6,4);(5,8)|] [|(2,6);(7,5);(3,1)|] |> should equal [|1;3;5;4;3;3;3;3;1;0|]
