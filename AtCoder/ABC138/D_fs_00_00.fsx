#r "nuget: FsUnit"
open FsUnit
open System.Collections.Generic

let N,Q,aba,pxa = 4,3,[|(1,2);(2,3);(2,4)|],[|(2,10);(1,100);(3,1)|]
let N,Q,aba,pxa = 6,2,[|(1,2);(1,3);(2,4);(3,6);(2,5)|],[|(1,10);(1,10)|]
let N,Q,aba,pxa = 3,3,[|(1,3);(2,3)|],[|(2,10);(3,100);(1,1)|]
let solve N Q aba pxa =
  let nbhs = (Array.create N ([]:list<int>),aba) ||> Array.fold (fun acc (a,b) ->
    Array.set acc (a-1) (b-1::acc.[a-1])
    Array.set acc (b-1) (a-1::acc.[b-1])
    acc)
  let cs = (Array.zeroCreate N,pxa) ||> Array.fold (fun acc (p,x) -> Array.set acc (p-1) (acc.[p-1]+x); acc)
  let rec f p0 v0 cs0 =
    Array.set cs v0 (cs.[p0]+cs.[v0])
    nbhs.[v0] |> List.filter ((<>) p0) |> List.fold (fun cs1 v1 -> f v0 v1 cs1) cs0
  (cs, nbhs.[0]) ||> List.fold (fun cs0 v0 -> f 0 v0 cs0)

let N,Q = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let aba = [| for i in 1..(N-1) do (stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1]) |]
let pxa = [| for i in 1..Q do (stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1]) |]
solve N Q aba pxa |> Array.map string |> String.concat " " |> stdout.WriteLine

solve 4 3 [|(1,2);(2,3);(2,4)|] [|(2,10);(1,100);(3,1)|] |> should equal (seq [|100;110;111;110|])
solve 6 2 [|(1,2);(1,3);(2,4);(3,6);(2,5)|] [|(1,10);(1,10)|] |> should equal (seq [|20;20;20;20;20;20|])
solve 3 3 [|(1,3);(2,3)|] [|(2,10);(3,100);(1,1)|] |> should equal (seq [|1;111;101|])
