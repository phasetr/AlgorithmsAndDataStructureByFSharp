#r "nuget: FsUnit"
open FsUnit

(*
let N,M,Ia = 6,7,[|(1,2,5);(1,4,4);(2,3,4);(2,5,7);(3,6,3);(4,5,3);(5,6,5)|]
*)
let solve N M Ia =
  let caps =
    (Array2D.create N N 0, Ia)
    ||> Array.fold (fun caps (a,b,c) -> caps.[a-1,b-1] <- c; caps)

  let searchPath s g =
    let srch = System.Collections.Generic.Queue<int>() |> fun q -> q.Enqueue(s); q
    let bfr = Array.create N (-1) |> fun bfr -> bfr.[s] <- 0; bfr

    let rec frec b =
      if srch.Count = 0 then false
      else
        let i = srch.Dequeue()
        if i=g then true
        else
          for j in 0..(N-1) do if bfr.[j]<0 && 0<caps.[i,j] then srch.Enqueue(j); bfr.[j] <- i
          frec b
    (frec false, bfr)

  let updateFlow s g (bfr:int[]) =
    let rec frec c j =
      if j=s then c
      else let i = bfr.[j] in frec (min caps.[i,j] c) i
    let c = frec System.Int32.MaxValue g
    let rec grec j =
      if j<>s then let i = bfr.[j] in caps.[i,j] <- caps.[i,j]-c; caps.[j,i] <- caps.[j,i]+c; grec i
    grec g
    c

  let maxFlow s g =
    let rec frec acc =
      let (b, bfr) = searchPath s g
      if b then frec (acc + updateFlow s g bfr) else acc
    frec 0

  maxFlow 0 (N-1)

let N,M = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Ia = Array.init M (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1],x.[2])
solve N M Ia |> stdout.WriteLine

solve 6 7 [|(1,2,5);(1,4,4);(2,3,4);(2,5,7);(3,6,3);(4,5,3);(5,6,5)|] |> should equal 8
