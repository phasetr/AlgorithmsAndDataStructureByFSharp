#r "nuget: FsUnit"
open FsUnit

let N,Aa = 4,[|10L;20L;30L;40L|]
let solve N (Aa:int64[]) =
    let acc = (Array.zeroCreate (N+1), [|0..(N-1)|]) ||> Array.fold (fun acc i -> Array.set acc (i+1) (Aa.[i] + acc.[i]); acc)
    (Array2D.zeroCreate N N, [|1..N-1|])
    ||> Array.fold (fun dp w ->
        (dp, [|0..(N-w-1)|])
        ||> Array.fold (fun dp l ->
            let v = Array.init w (fun i -> dp.[l,l+i]+dp.[l+i+1,l+w]) |> Array.fold min System.Int64.MaxValue
            Array2D.set dp l (l+w) (acc.[l+w+1] - acc.[l] + v); dp))
    |> fun dp -> dp.[0,N-1]
let N = stdin.ReadLine() |> int
let Aa = stdin.ReadLine().Split() |> Array.map int64
solve N Aa |> stdout.WriteLine

solve 4 [|10L;20L;30L;40L|] |> should equal 190L
solve 5 [|10L;10L;10L;10L;10L|] |> should equal 120L
solve 3 [|1000000000L;1000000000L;1000000000L|] |> should equal 5000000000L
solve 6 [|7L;6L;8L;6L;1L;1L|] |> should equal 68L
