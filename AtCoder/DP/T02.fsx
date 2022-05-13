#r "nuget: FsUnit"
open FsUnit

let N,s = 4,"<><"
let solve N (s:string) =
    let MOD = 1_000_000_007
    let (.+.) x y = (x+y)%MOD

    let mutable dp: int[,] = Array2D.zeroCreate N N
    for i in 0..N-1 do dp[0,i] <- 1
    for i in 0..N-2 do
        let mutable cum:int[] = Array.zeroCreate (N+1-i)
        for j in 0..(N-i-1) do cum.[j+1] <- cum.[j] .+. dp.[i,j]
        for j in 0..(N-i-1) do
            if s.[i]='<' then dp.[i+1,j] <- cum.[j+1]
            else dp.[i+1,j] <- (cum.[N-i]-cum.[j+1]+MOD)%MOD
    dp.[N-1,0]
let N = stdin.ReadLine() |> int
let s = stdin.ReadLine()
solve N s |> stdout.WriteLine

solve 4 "<><" |> should equal 5
solve 5 "<<<<" |> should equal 1
solve 20 ">>>><>>><>><>>><<>>" |> should equal 217136290
