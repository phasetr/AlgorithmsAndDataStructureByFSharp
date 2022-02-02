@"https://atcoder.jp/contests/dp/tasks/dp_d"
#r "nuget: FsUnit"
open FsUnit

@"https://atcoder.jp/contests/dp/submissions/7243556"
let solve N W (wvs: array<int*int64>) =
    let dp = Array2D.create (N+1) (W+1) 0L
    for i = 1 to N do
        let (w,v) = wvs.[i-1]
        for j = 0 to W do
            if j - w >= 0 then
                dp.[i,j] <- max dp.[i-1,j] (dp.[i-1, j-w] + v)
            else dp.[i,j] <- dp.[i-1,j]
    dp.[N,W]

let N, W = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
let wvs = [| for i in 1..N do (stdin.ReadLine().Split() |> fun x -> int x.[0], int64 x.[1]) |]
solve N W wvs |> stdout.WriteLine

solve 3 8 [|(3,30L);(4,50L);(5,60L)|] |> should equal 90L
solve 5 5 [|(1,1000000000L);(1,1000000000L);(1,1000000000L);(1,1000000000L);(1,1000000000L)|] |> should equal 5000000000L
solve 6 15 [|(6,5L);(5,6L);(6,4L);(6,6L);(3,5L);(7,2L)|] |> should equal 17L
