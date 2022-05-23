#r "nuget: FsUnit"
open FsUnit

let N,K,Aa = 4,2L,(array2D [|[|0L;1L;0L;0L|];[|0L;0L;1L;1L|];[|0L;0L;0L;1L|];[|1L;0L;0L;0L|]|])
let N,K,Aa = 10,1000000000000000000L,(array2D [|[|0;0;1;1;0;0;0;1;1;0|];[|0;0;0;0;0;1;1;1;0;0|];[|0;1;0;0;0;1;0;1;0;1|];[|1;1;1;0;1;1;0;1;1;0|];[|0;1;1;1;0;1;0;1;1;1|];[|0;0;0;1;0;0;1;0;1;0|];[|0;0;0;1;1;0;0;1;0;1|];[|1;0;0;0;1;0;1;0;0;0|];[|0;0;0;0;0;1;0;0;0;0|];[|1;0;1;1;1;0;1;1;1;0|]|])
let solve N K Aa =
    let m = 1_000_000_007L
    let times (A:int64[,]) (B:int64[,]) =
        let mutable ca = Array2D.zeroCreate N N
        for i in 0..N-1 do
            for j in 0..N-1 do
                for k in 0..N-1 do
                    ca.[i,j] <- (ca.[i,j]+A.[i,k]*B.[k,j])%m
        ca
    let rec expn A k =
        if k=0L then [|0..N-1|] |> Array.map (fun i -> [|0..N-1|] |> Array.map (fun j -> if i=j then 1L else 0L)) |> array2D
        elif k%2L=0L then expn (times A A) (k/2L)
        else times A (expn A (k-1L))
    let X = expn Aa K
    (0L,Array.allPairs [|0..N-1|] [|0..N-1|])
    ||> Array.fold (fun acc (i,j) -> (acc + X.[i,j])%m)
let N,K = stdin.ReadLine().Split() |> (fun x -> int x.[0], int64 x.[1])
let Aa = [| for i in 1..N do (stdin.ReadLine().Split() |> Array.map int64) |] |> array2D
solve N K Aa |> stdout.WriteLine

solve 4 2L (array2D [|[|0L;1L;0L;0L|];[|0L;0L;1L;1L|];[|0L;0L;0L;1L|];[|1L;0L;0L;0L|]|]) |> should equal 6
solve 3 3L (array2D [|[|0L;1L;0L|];[|1L;0L;1L|];[|0L;0L;0L|]|]) |> should equal 3
solve 6 2L (array2D [|[|0L;0L;0L;0L;0L;0L|];[|0L;0L;1L;0L;0L;0L|];[|0L;0L;0L;0L;0L;0L|];[|0L;0L;0L;0L;1L;0L|];[|0L;0L;0L;0L;0L;1L|];[|0L;0L;0L;0L;0L;0L|]|]) |> should equal 1
solve 1 1L (array2D [|[|0L|]|]) |> should equal 0
solve 10 1000000000000000000L (array2D [|[|0L;0L;1L;1L;0L;0L;0L;1L;1L;0L|];[|0L;0L;0L;0L;0L;1L;1L;1L;0L;0L|];[|0L;1L;0L;0L;0L;1L;0L;1L;0L;1L|];[|1L;1L;1L;0L;1L;1L;0L;1L;1L;0L|];[|0L;1L;1L;1L;0L;1L;0L;1L;1L;1L|];[|0L;0L;0L;1L;0L;0L;1L;0L;1L;0L|];[|0L;0L;0L;1L;1L;0L;0L;1L;0L;1L|];[|1L;0L;0L;0L;1L;0L;1L;0L;0L;0L|];[|0L;0L;0L;0L;0L;1L;0L;0L;0L;0L|];[|1L;0L;1L;1L;1L;0L;1L;1L;1L;0L|]|]) |> should equal 957538352
