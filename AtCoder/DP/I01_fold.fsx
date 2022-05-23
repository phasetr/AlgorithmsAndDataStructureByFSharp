#r "nuget: FsUnit"
open FsUnit
let N,Pa = 3,[|0.30;0.60;0.80|]
let solve N (Pa:float[]) =
    Array2D.zeroCreate (N+1) (N+1)
    |> fun dp -> Array2D.set dp 0 0 1.0; (dp, [|1..N|])
    ||> Array.fold (fun dp i ->
        (dp, [|0..i|]) ||> Array.fold (fun dp j ->
            if j=0 then Array2D.set dp i j (dp.[i-1,j] * (1.0-Pa.[i-1])); dp
            else Array2D.set dp i j (dp.[i-1,j]*(1.0-Pa.[i-1]) + dp.[i-1,j-1]*Pa.[i-1]); dp))
    |> fun dp -> (0.0,[|(N/2+1)..N|]) ||> Array.fold (fun s i -> s+dp.[N,i])
let N = stdin.ReadLine() |> int
let Pa = stdin.ReadLine().Split() |> Array.map float
solve N Pa |> stdout.WriteLine

let near0 x y = (abs (x-y)) < 0.000_000_000_1
near0 (solve 3 [|0.30;0.60;0.80|]) 0.612 |> should be True
near0 (solve 1 [|0.50|]) 0.5 |> should be True
near0 (solve 5 [|0.42;0.01;0.42;0.99;0.42|]) 0.382_181_587_2 |> should be True
