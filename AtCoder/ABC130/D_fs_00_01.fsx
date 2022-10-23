#r "nuget: FsUnit"
open FsUnit

let N,K,Aa = 4L,10L,[|6L;1L;2L;7L|]
let solve N K (Aa:int64[]) =
  let Sa = Array.scan (+) 0L Aa
  let rec frec acc s l r =
    if K<=s then if l = int(N-1L) then acc else frec acc (s-Aa.[l]) (l+1) r
    else let acc=acc- int64(r-l) in if r=int N then acc else frec acc (s+Aa.[r]) l (r+1)
  frec ((N+1L)*N/2L) 0L 0 0

let N,K = stdin.ReadLine().Split() |> Array.map int64 |> (fun x -> x.[0], x.[1])
let Aa = stdin.ReadLine().Split() |> Array.map int64
solve N K Aa |> stdout.WriteLine

solve 4L 10L [|6L;1L;2L;7L|] |> should equal 2L
solve 3L 5L [|3L;3L;3L|] |> should equal 3L
solve 10L 53462L [|103L;35322L;232L;342L;21099L;90000L;18843L;9010L;35221L;19352L|] |> should equal 36L
