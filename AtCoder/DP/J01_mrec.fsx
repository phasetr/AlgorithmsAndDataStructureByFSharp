#r "nuget: FsUnit"
open FsUnit
let N,Aa = 3,[|1;1;1|]
let solve N Aa =
    let rec f (dp:float[,,]) i1 i2 i3 =
        if dp.[i1,i2,i3]=(-1.0) then
            let numer =
                (float N)
                + (if i1=0 then 0.0 else ((float i1) * fst (f dp (i1-1) i2     i3)))
                + (if i2=0 then 0.0 else ((float i2) * fst (f dp (i1+1) (i2-1) i3)))
                + (if i3=0 then 0.0 else ((float i3) * fst (f dp i1     (i2+1) (i3-1))))
            let denom = float (i1+i2+i3)
            let res = numer / denom
            Array3D.set dp i1 i2 i3 res
            (res, dp)
        else (dp.[i1,i2,i3], dp)

    let cnt =
        Array.zeroCreate 4
        |> fun cnt -> (Aa |> Array.map (fun i -> Array.set cnt i (cnt.[i]+1); cnt))
        |> Array.head

    Array3D.init (N+1) (N+1) (N+1) (fun _ _ _ -> -1.0)
    |> fun dp -> Array3D.set dp 0 0 0 0.0; dp
    |> fun dp -> f dp cnt.[1] cnt.[2] cnt.[3] |> fst

let N = stdin.ReadLine() |> int
let Aa = stdin.ReadLine().Split() |> Array.map int
solve N Aa |> stdout.WriteLine

let near0 x y = (abs (x-y)) < 0.000_000_01
near0 (solve 3 [|1;1;1|]) 5.5 |> should be True
near0 (solve 1 [|3|]) 3 |> should be True
near0 (solve 2 [|1;2|]) 4.5 |> should be True
near0 (solve 10 [|1;3;2;3;3;2;3;2;1;3|]) 54.48064457488221 |> should be True
