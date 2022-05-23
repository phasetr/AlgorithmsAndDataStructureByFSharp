#r "nuget: FsUnit"
open FsUnit

let N,K,Aa = 3,4,[|1;2;3|]
let solve N K (Aa:int[]) =
    let num = 1_000_000_007
    let (+@) a b = (a+b) % num
    let (-@) a b = (a-b+num) % num
    (Array2D.zeroCreate (N+1) (K+1), [|0..K|])
    ||> Array.fold (fun dp i -> Array2D.set dp 0 i 1; dp)
    |> (fun dp ->
        (dp, [|1..N|])
        ||> Array.fold (fun dp i ->
            Array2D.set dp i 0 1
            (dp, [|1..K|])
            ||> Array.fold (fun dp j ->
                Array2D.set dp i j (dp.[i,j-1] +@ if 0<j-Aa.[i-1] then dp.[i-1,j] -@ dp.[i-1,j-Aa.[i-1]-1] else dp.[i-1,j])
                dp)))
    |> fun dp -> if K=0 then dp.[N,0] else dp.[N,K] -@ dp.[N,K-1]
let N,K = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
let Aa = stdin.ReadLine().Split() |> Array.map int
solve N K Aa |> stdout.WriteLine

solve 3 4 [|1;2;3|] |> should equal 5
solve 1 10 [|9|] |> should equal 0
solve 2 0 [|0;0|] |> should equal 1
solve 4 100000 [|100000;100000;100000;100000|] |> should equal 665683269
