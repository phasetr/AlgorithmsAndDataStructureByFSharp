#r "nuget: FsUnit"
open FsUnit
let N,M,Aa = 4,5,[|(1,2);(1,3);(3,2);(2,4);(3,4)|]
let solve N M (Aa:array<int*int>) =
    let mutable g = Array.create N List.empty<int>
    for (x,y) in Aa do g.[x-1] <- (y-1) :: g.[x-1]

    let mutable dp = Array.create N -1
    let rec frec v =
        if dp.[v] <> -1 then dp.[v]
        else
            let mutable res = 0
            for nv in g.[v] do
                res <- max res (frec nv + 1)
            dp.[v] <- res
            dp.[v]

    let mutable res = 0
    for i in [0..N-1] do res <- max res (frec i)
    res
let N,M = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
let Aa = [| for i in 1..M do (stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1]) |]
solve N M Aa |> stdout.WriteLine

solve 4 5 [|(1,2);(1,3);(3,2);(2,4);(3,4)|] |> should equal 3
solve 6 3 [|(2,3);(4,5);(5,6)|] |> should equal 2
solve 5 8 [|(5,3);(2,3);(2,4);(5,2);(5,1);(1,4);(4,3);(1,3)|] |> should equal 3
