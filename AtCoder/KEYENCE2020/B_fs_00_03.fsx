#r "nuget: FsUnit"
open FsUnit

let N,Aa = 4,[|(2,4);(4,3);(9,3);(100,5)|]
let N,Aa = 2,[|(8,20);(1,10)|]
let N,Aa = 5,[|(10,1);(2,1);(4,1);(6,1);(8,1)|]
let solve N Aa =
  Aa |> Array.map (fun (x,l) -> max 0 (x-l), x+l)
  |> Array.sortBy snd
  |> Array.fold (fun (acc,right) (a,b) -> if right <= a then (acc+1,b) else (acc,right)) (0,0)
  |> fst

let N = stdin.ReadLine() |> int
let Aa = [| for i in 1..N do (stdin.ReadLine().Split() |> fun x -> (int x.[0], int x.[1])) |]
solve N Aa |> stdout.WriteLine

solve 4 [|(2,4);(4,3);(9,3);(100,5)|] |> should equal 3
solve 2 [|(8,20);(1,10)|] |> should equal 1
solve 5 [|(10,1);(2,1);(4,1);(6,1);(8,1)|] |> should equal 5
