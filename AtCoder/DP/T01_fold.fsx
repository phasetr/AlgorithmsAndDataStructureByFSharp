#r "nuget: FsUnit"
open FsUnit

let N,s = 4,"<><"
let solve N (s:string) =
    let MOD = 1_000_000_007
    let (.+.) x y = (x+y)%MOD
    (Array2D.zeroCreate N N, [|0..N-1|])
    ||> Array.fold (fun dp i -> Array2D.set dp 0 i 1; dp)
    |> fun dp ->
        (dp, [|0..N-2|])
        ||> Array.fold (fun dp i ->
            (Array.zeroCreate (N+1-i), [|0..(N-i-1)|])
            ||> Array.fold (fun cum j -> Array.set cum (j+1) (cum.[j] .+. dp.[i,j]); cum)
            |> fun cum ->
                (dp, [|0..(N-i-1)|])
                ||> Array.fold (fun dp j ->
                    if s.[i]='<' then Array2D.set dp (i+1) j cum.[j+1]; dp
                    else Array2D.set dp (i+1) j ((cum.[N-i] - cum.[j+1] + MOD)%MOD); dp))
    |> fun dp -> dp.[N-1,0]
let N = stdin.ReadLine() |> int
let s = stdin.ReadLine()
solve N s |> stdout.WriteLine

solve 4 "<><" |> should equal 5
solve 5 "<<<<" |> should equal 1
solve 20 ">>>><>>><>><>>><<>>" |> should equal 217136290
