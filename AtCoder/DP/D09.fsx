@"https://atcoder.jp/contests/dp/tasks/dp_d"
#r "nuget: FsUnit"
open FsUnit

let solve N W (wva: array<int*int64>) =
    let init = Array.replicate (W+1) 0L
    let f acc (w,v) =
        printfn "%A" (w,v,acc)
        let pick =
            Array.append (Array.replicate w (-v)) acc
            |> Array.truncate (Array.length acc)
            |> Array.map ((+) v)
        Array.map2 max acc pick
    Array.fold f init wva |> Array.last
let N, W = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
let wva = [| for i in 1..N do (stdin.ReadLine().Split() |> fun x -> int x.[0], int64 x.[1]) |]
solve N W wva |> stdout.WriteLine

solve 3 8 [|(3,30L);(4,50L);(5,60L)|] |> should equal 90L
solve 5 5 [|(1,1000000000L);(1,1000000000L);(1,1000000000L);(1,1000000000L);(1,1000000000L)|] |> should equal 5000000000L
solve 6 15 [|(6,5L);(5,6L);(6,4L);(6,6L);(3,5L);(7,2L)|] |> should equal 17L
