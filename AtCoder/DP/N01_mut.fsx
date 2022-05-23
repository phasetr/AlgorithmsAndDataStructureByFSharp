#r "nuget: FsUnit"
open FsUnit

let N,Aa = 4,[|10L;20L;30L;40L|]
let solve N (Aa:int64[]) =
    let mutable acc = Array.zeroCreate (N+1)
    for i in 0..N-1 do acc.[i+1] <- Aa.[i] + acc.[i]

    let mutable dp = Array2D.zeroCreate N N
    for w in 1..N-1 do
        for l in 0..(N-w-1) do
            let v = Array.init w (fun i -> dp.[l,l+i]+dp.[l+i+1,l+w]) |> Array.fold min System.Int64.MaxValue
            dp.[l,l+w] <- acc.[l+w+1] - acc.[l] + v
    dp.[0,N-1]
let N = stdin.ReadLine() |> int
let Aa = stdin.ReadLine().Split() |> Array.map int64
solve N Aa |> stdout.WriteLine

solve 4 [|10L;20L;30L;40L|] |> should equal 190L
solve 5 [|10L;10L;10L;10L;10L|] |> should equal 120L
solve 3 [|1000000000L;1000000000L;1000000000L|] |> should equal 5000000000L
solve 6 [|7L;6L;8L;6L;1L;1L|] |> should equal 68L
