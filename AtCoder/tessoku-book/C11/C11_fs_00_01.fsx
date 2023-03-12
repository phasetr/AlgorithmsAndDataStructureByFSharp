#r "nuget: FsUnit"
open FsUnit

(*
let N,K,Aa = 4L,10L,[|1000000L;700000L;300000L;180000L|]
let N,K,Aa = 2L,3L,[|6000L;3000L|]
let N,K,Aa = 15L,50L,[|18256245L;7845995L;6771945L;6181431L;3618432L;3159625L;2319156L;1768385L;1258501L;1253872L;193724L;148020L;109045L;77861L;65107L|]
let N,K,Aa = 2L,1L,[|900000000L;100000000L|]
*)
let solve N K Aa =
  let M = 1_000_000L
  let l =
    let mutable r,l = 1_000_000_000_000_000L,1L
    while r-l > 1L do
      let m = (r+l)/2L
      (0L,Aa) ||> Array.fold (fun acc a -> acc + a*M/m)
      |> fun cnt -> if K<=cnt then l <- m else r <- m
    int64 l
  Aa |> Array.map (fun a -> a*M/l)

let N,K = stdin.ReadLine().Split() |> Array.map int64 |> (fun x -> x.[0],x.[1])
let Aa = stdin.ReadLine().Split() |> Array.map int64
solve N K Aa |> Array.map string |> String.concat " " |> stdout.WriteLine

solve 4L 10L [|1000000L;700000L;300000L;180000L|] |> should equal [|5L;3L;1L;1L|]
solve 2L 3L [|6000L;3000L|] |> should equal [|2L;1L|]
solve 15L 50L [|18256245L;7845995L;6771945L;6181431L;3618432L;3159625L;2319156L;1768385L;1258501L;1253872L;193724L;148020L;109045L;77861L;65107L|] |> should equal [|18L;8L;7L;6L;3L;3L;2L;1L;1L;1L;0L;0L;0L;0L;0L|]
solve 2L 1L [|900000000L;100000000L|] |> should equal [|1L;0L|]
