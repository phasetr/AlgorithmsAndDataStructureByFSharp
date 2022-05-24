#r "nuget: FsUnit"
open FsUnit

let N,Xa = 3,[|(2,2,20L);(2,1,30L);(3,1,40L)|]
let solve N (Xa:(int*int*int64)[]) =
    let Ya = Array.sortBy (fun (w,v,_) -> w+v) Xa
    let W = 10_000
    let mutable dp:int64[] = Array.zeroCreate (2*W+1)
    for w,s,v in Ya do
        for i in w+s..(-1)..w do
            dp.[i] <- max dp.[i] (dp.[i-w]+v)
    Array.max dp
let N = stdin.ReadLine() |> int
let Xa = [| for i in 1..N do (stdin.ReadLine().Split() |> fun x -> int x.[0], int x.[1], int64 x.[2]) |]
solve N Xa |> stdout.WriteLine

solve 3 [|(2,2,20L);(2,1,30L);(3,1,40L)|] |> should equal 50L
