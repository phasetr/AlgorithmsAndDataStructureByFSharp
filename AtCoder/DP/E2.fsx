@"https://atcoder.jp/contests/dp/submissions/7243886"
#r "nuget: FsUnit"
open FsUnit

let solve N W (wvs: array<int*int>) =
    let vmax = pown 10 5
    let inf = pown 10 9 + 10
    let dp = Array2D.create (N+1) (vmax+1) inf
    dp.[0,0] <- 0
    for i = 1 to N do
        let (w,v) = wvs.[i-1]
        for j = 0 to vmax do
            if j - v < 0 then dp.[i,j] <- dp.[i-1,j]
            else dp.[i,j] <- min dp.[i-1,j] (dp.[i-1,j-v] + w)
    [|0..vmax|]
    |> Array.choose (fun i -> if dp.[N,i] <= W then Some i else None)
    |> Array.max

let N, W = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
let wvs = [| for i in 1..N do (stdin.ReadLine().Split() |> fun x -> int x.[0], int x.[1]) |]
solve N W wvs |> stdout.WriteLine

solve 3 8 [|(3,30);(4,50);(5,60)|] |> should equal 90
solve 1 1000000000 [|(1000000000,10)|] |> should equal 10
solve 6 15 [|(6,5);(5,6);(6,4);(6,6);(3,5);(7,2)|] |> should equal 17
