#r "nuget: FsUnit"
open FsUnit

(*
let N,Ia = 7,[|(1,1);(4,1);(2,5);(3,4);(3,2);(4,2);(5,5)|]
*)
let solve N (Ia:(int*int)[]) =
  let l2sq (x1,y1) (x2,y2) = pown (x1-x2) 2 + pown (y1-y2) 2
  let init =
    let route = Array.create (N+1) 1
    let visited = Array.create N false
    visited.[0] <- true
    ((route,visited,0), [|1..N-1|])

  init ||> Array.fold (fun (route,visited,current) i ->
      let mutable minId = 0
      let mutable minDist = System.Int32.MaxValue
      [|1..N-1|] |> Array.iter (fun j ->
        if not visited.[j] then
          let d = l2sq Ia.[j] Ia.[current]
          if d<minDist then minId <- j; minDist <- d)
      visited.[minId] <- true
      route.[i] <- minId+1
      (route,visited,minId))
  |> fun (r,_,_) -> r

let N = stdin.ReadLine() |> int
let Ia = Array.init N (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1])
solve N Ia |> Array.iter stdout.WriteLine

solve 7 [|(1,1);(4,1);(2,5);(3,4);(3,2);(4,2);(5,5)|] |> should equal [|1;5;6;2;4;3;7;1|]
