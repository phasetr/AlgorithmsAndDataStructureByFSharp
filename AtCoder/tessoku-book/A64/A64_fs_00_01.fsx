#r "nuget: FsUnit"
open FsUnit

(*
let N,M,Ia = 6,7,[|(1,2,15L);(1,4,20L);(2,3,65L);(2,5,4L);(3,6,50L);(4,5,30L);(5,6,8L)|]
let N,M,Ia = 15,30,[|(10,11,23L);(11,13,24L);(5,8,22L);(10,15,18L);(12,14,15L);(2,10,11L);(4,7,15L);(5,7,15L);(7,9,8L);(8,12,1L);(5,14,1L);(10,14,17L);(10,12,11L);(8,10,6L);(7,14,28L);(6,9,1L);(1,10,19L);(4,5,4L);(9,10,21L);(7,10,21L);(4,10,29L);(5,10,8L);(4,14,8L);(11,12,24L);(10,13,13L);(3,10,1L);(5,12,24L);(2,15,23L);(6,10,18L);(6,15,25L)|]
*)
let solve N M Ia =
  let Ma = (Array.create (N+1) [], Ia) ||> Array.fold (fun m (a,b,c) ->
    m.[a] <- (a,b,c)::m.[a]
    m.[b] <- (b,a,c)::m.[b]
    m)
  let dijkstra (Ma:(int*int*int64)list[]) =
    let n = Array.length Ma
    let Ca = Array.create n System.Int64.MaxValue |> fun c -> c.[1] <- 0L; c
    let q = System.Collections.Generic.SortedSet<int64*int>() |> fun q -> q.Add(0L,1) |> ignore; q
    while q.Count > 0 do
      let (c0,v0) = q.Min
      q.Remove((c0,v0)) |> ignore
      if v0<>(-1) then
        Ma.[v0] |> List.iter (fun (a,b,c) ->
          let (nv,nc) = (b,c+c0)
          if nc < Ca.[nv] then
            if Ca.[nv] <> System.Int64.MaxValue then q.Remove((Ca.[nv],nv)) |> ignore
            q.Add((nc,nv)) |> ignore
            Ca.[nv] <- nc)
    Ca |> Array.map (fun x -> if x=System.Int64.MaxValue then -1L else x)
  dijkstra Ma |> Array.tail

let N,M = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Ia = Array.init M (fun _ -> stdin.ReadLine().Split() |> fun x -> int x.[0],int x.[1],int64 x.[2])
solve N M Ia |> Array.iter stdout.WriteLine

solve 6 7 [|(1,2,15L);(1,4,20L);(2,3,65L);(2,5,4L);(3,6,50L);(4,5,30L);(5,6,8L)|] |> should equal [|0L;15L;77L;20L;19L;27L|]
solve 15 30 [|(10,11,23L);(11,13,24L);(5,8,22L);(10,15,18L);(12,14,15L);(2,10,11L);(4,7,15L);(5,7,15L);(7,9,8L);(8,12,1L);(5,14,1L);(10,14,17L);(10,12,11L);(8,10,6L);(7,14,28L);(6,9,1L);(1,10,19L);(4,5,4L);(9,10,21L);(7,10,21L);(4,10,29L);(5,10,8L);(4,14,8L);(11,12,24L);(10,13,13L);(3,10,1L);(5,12,24L);(2,15,23L);(6,10,18L);(6,15,25L)|] |> should equal [|0L;30L;20L;31L;27L;37L;40L;25L;38L;19L;42L;26L;32L;28L;37L|]
