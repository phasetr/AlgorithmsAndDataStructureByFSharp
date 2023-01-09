#r "nuget: FsUnit"
open FsUnit

(*
let N,Ia = 7,[|(1,1);(4,1);(2,5);(3,4);(3,2);(4,2);(5,5)|]
*)
let solve N (Ia:(int*int)[]) =
  let l2sq (x1,y1) (x2,y2) = pown (x1-x2) 2 + pown (y1-y2) 2

  let mutable visited = Array.create N false
  let mutable route = Array.create (N+1) 1
  visited.[0] <- true
  let mutable current = 0
  for i in 1..N-1 do
    let mutable m = (0,System.Int32.MaxValue)
    for j in 1..N-1 do
      if not visited.[j] then
        let d = l2sq Ia.[j] Ia.[current]
        if d<snd m then m <- (j,d)
    visited.[fst m] <- true
    route.[i] <- fst m + 1
    current <- fst m
  route

let N = stdin.ReadLine() |> int
let Ia = Array.init N (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1])
solve Ia |> Array.iter stdout.WriteLine

solve 7 [|(1,1);(4,1);(2,5);(3,4);(3,2);(4,2);(5,5)|] |> should equal [|1;5;6;2;4;3;7;1|]
// |> should equal [|1;2;6;7;3;4;5;1|]
