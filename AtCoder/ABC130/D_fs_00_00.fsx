#r "nuget: FsUnit"
open FsUnit

let N,K,Aa = 4L,10L,[|6L;1L;2L;7L|]
let solve N K (Aa:int64[]) =
  let rec frec acc k l r =
    if Aa.Length <= l then acc
    elif K <= k then frec (acc+N-(int64 r)+1L) (k-Aa.[l]) (l+1) r
    else if Aa.Length <= r then acc else frec acc (k+Aa.[r]) l (r+1)
  frec 0L 0L 0 0

let N,K = stdin.ReadLine().Split() |> Array.map int64 |> (fun x -> x.[0],x.[1])
let Aa = stdin.ReadLine().Split() |> Array.map int64
solve N K Aa |> stdout.WriteLine

solve 4L 10L [|6L;1L;2L;7L|] |> should equal 2L
solve 3L 5L [|3L;3L;3L|] |> should equal 3L
solve 10L 53462L [|103L;35322L;232L;342L;21099L;90000L;18843L;9010L;35221L;19352L|] |> should equal 36L
