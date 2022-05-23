#r "nuget: FsUnit"
open FsUnit

let K,D = "30",4
let K,D = "1000000009",1
let solve K D =
    let MOD = 1_000_000_007
    let N = String.length K
    let (.+) x y = (x+y)%MOD
    let inline charToInt c = int c - int '0'

    ((0, Array2D.zeroCreate (N+1) D), [|0..(N-1)|])
    ||> Array.fold (fun (digitSum,dp) i ->
        (dp,[|0..(D-1)|])
        ||> Array.fold (fun dp j ->
            (dp,[|0..9|])
            ||> Array.fold (fun dp l ->
                let j0 = ((j-l)%D + D)%D
                Array2D.set dp (i+1) j (dp.[i+1,j] .+ dp.[i,j0]); dp))
        |> fun dp ->
            let ki = charToInt K.[i]
            (dp, [|0..(ki-1)|])
            ||> Array.fold (fun dp j ->
                let d0 = (digitSum+j)%D
                Array2D.set dp (i+1) d0 (dp.[i+1,d0]+1); dp)
            |> fun dp -> ((digitSum + ki)%D,dp))
    |> fun (digitSum,dp) ->
        Array2D.set dp N 0 (dp.[N,0]-1)
        Array2D.set dp N digitSum (dp.[N,digitSum]+1)
        dp.[N,0]%MOD
let K = stdin.ReadLine()
let D = stdin.ReadLine() |> int
solve K D |> stdout.WriteLine

solve "30" 4 |> should equal 6
solve "1000000009" 1 |> should equal 2
solve "98765432109876543210" 58 |> should equal 635270834
solve "2000000014" 2 |> should equal 1000000006
