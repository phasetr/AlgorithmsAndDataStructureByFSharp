#r "nuget: FsUnit"
open FsUnit

(*
let N,M,Ia = 6,7,[|(1,2,5);(1,4,4);(2,3,4);(2,5,7);(3,6,3);(4,5,3);(5,6,5)|]
*)
let solve N M Ia =
  let caps =
    (Array2D.create (N+1) (N+1) 0, Ia)
    ||> Array.fold (fun caps (a,b,c) -> caps.[a,b] <- c; caps)
  let mutable bfr = Array.create (N+1) (-1)

  let searchPath s g =
    let srch = System.Collections.Generic.Queue<int>() |> fun q -> q.Enqueue(s); q
    bfr <- Array.create (N+1) (-1) |> fun bfr -> bfr.[s] <- 0; bfr

    let rec frec b =
      if srch.Count = 0 then false
      else
        let i = srch.Dequeue()
        if i=g then true
        else
          for j in 1..N do
            if bfr.[j]<0 && 0<caps.[i,j] then srch.Enqueue(j); bfr.[j] <- i
          frec b
    frec false

  let updateFlow s g =
    let mutable c = System.Int32.MaxValue
    let mutable j = g
    while j<>s do
      let i = bfr.[j]
      c <- min caps.[i,j] c
      j <- i
      ()
    let mutable j = g
    while j<>s do
      let i = bfr.[j]
      caps.[i,j] <- caps.[i,j]-c
      caps.[j,i] <- caps.[j,i]+c
      j <- i
      ()
    c

  let maxFlow s g =
    let mutable ttl = 0
    while searchPath s g do ttl <- ttl + updateFlow s g
    ttl

  maxFlow 1 N

let N,M = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Ia = Array.init M (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1],x.[2])
solve N M Ia |> stdout.WriteLine

solve 6 7 [|(1,2,5);(1,4,4);(2,3,4);(2,5,7);(3,6,3);(4,5,3);(5,6,5)|] |> should equal 8
