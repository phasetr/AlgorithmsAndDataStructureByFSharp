@"https://atcoder.jp/contests/dp/tasks/dp_g"
#r "nuget: FsUnit"
open FsUnit
let N,M,Aa = 4,5,[|(1,2);(1,3);(3,2);(2,4);(3,4)|]
@"https://atcoder.jp/contests/dp/submissions/3944462"
let solve N M (Aa:array<int*int>) =
    let g =
        (Array.create N List.empty<int>, [|0..M-1|])
        ||> Array.fold (fun g i ->
            let (x,y) = Aa.[i]
            Array.set g (x-1) ((y-1) :: g.[x-1])
            g)
    let dp = Array.replicate N -1 in
        let rec f v =
            if 0<=dp.[v] then dp.[v]
            else
                let l = 1 + List.fold (fun s w -> max s (f w)) (-1) g.[v]
                Array.set dp v l
                l in
                    (0,[|0..(N-1)|]) ||> Array.fold (fun s i -> max s (f i))
let N,M = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
let Aa = [| for i in 1..M do (stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1]) |]
solve N M Aa |> stdout.WriteLine

solve 4 5 [|(1,2);(1,3);(3,2);(2,4);(3,4)|] |> should equal 3
solve 6 3 [|(2,3);(4,5);(5,6)|] |> should equal 2
solve 5 8 [|(5,3);(2,3);(2,4);(5,2);(5,1);(1,4);(4,3);(1,3)|] |> should equal 3
