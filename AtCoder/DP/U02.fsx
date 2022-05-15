#r "nuget: FsUnit"
open FsUnit

let N,Aa = 3,[|[|0L;10L;20L|];[|10L;0L;-100L|];[|20L;-100L;0L|]|]
let solve N (Aa:int64[][]) =
    let m = 1 <<< N
    let mutable dp:int64[] = Array.zeroCreate m
    let mutable cost:int64[] = Array.zeroCreate m
    for s in 0..(m-1) do
        for i in 0..(N-1) do
            for j in 0..(i-1) do
                if (s>>>i &&& 1 = 1) && (s>>>j &&& 1 = 1)
                then cost.[s] <- cost.[s] + Aa.[i].[j]
                else ()
    for s in 0..(m-1) do
        let mutable u = s
        while u <> 0 do
            dp.[s] <- max dp.[s] (dp.[s-u]+cost.[u])
            u <- (u-1) &&& s
    dp.[m-1]
let N = stdin.ReadLine() |> int
let Aa = [| for i in 1..N do (stdin.ReadLine().Split() |> Array.map int64) |]
solve N Aa |> stdout.WriteLine

solve 3 [|[|0L;10L;20L|];[|10L;0L;-100L|];[|20L;-100L;0L|]|] |> should equal 20L
solve 2 [|[|0L;-10L|];[|-10L;0L|]|] |> should equal 0L
solve 4 [|[|0L;1000000000L;1000000000L;1000000000L|];[|1000000000L;0L;1000000000L;1000000000L|];[|1000000000L;1000000000L;0L;-1L|];[|1000000000L;1000000000L;-1L;0L|]|] |> should equal 4999999999L
solve 16 [|[|0L;5L;-4L;-5L;-8L;-4L;7L;2L;-4L;0L;7L;0L;2L;-3L;7L;7L|];[|5L;0L;8L;-9L;3L;5L;2L;-7L;2L;-7L;0L;-1L;-4L;1L;-1L;9L|];[|-4L;8L;0L;-9L;8L;9L;3L;1L;4L;9L;6L;6L;-6L;1L;8L;9L|];[|-5L;-9L;-9L;0L;-7L;6L;4L;-1L;9L;-3L;-5L;0L;1L;2L;-4L;1L|];[|-8L;3L;8L;-7L;0L;-5L;-9L;9L;1L;-9L;-6L;-3L;-8L;3L;4L;3L|];[|-4L;5L;9L;6L;-5L;0L;-6L;1L;-2L;2L;0L;-5L;-2L;3L;1L;2L|];[|7L;2L;3L;4L;-9L;-6L;0L;-2L;-2L;-9L;-3L;9L;-2L;9L;2L;-5L|];[|2L;-7L;1L;-1L;9L;1L;-2L;0L;-6L;0L;-6L;6L;4L;-1L;-7L;8L|];[|-4L;2L;4L;9L;1L;-2L;-2L;-6L;0L;8L;-6L;-2L;-4L;8L;7L;7L|];[|0L;-7L;9L;-3L;-9L;2L;-9L;0L;8L;0L;0L;1L;-3L;3L;-6L;-6L|];[|7L;0L;6L;-5L;-6L;0L;-3L;-6L;-6L;0L;0L;5L;7L;-1L;-5L;3L|];[|0L;-1L;6L;0L;-3L;-5L;9L;6L;-2L;1L;5L;0L;-2L;7L;-8L;0L|];[|2L;-4L;-6L;1L;-8L;-2L;-2L;4L;-4L;-3L;7L;-2L;0L;-9L;7L;1L|];[|-3L;1L;1L;2L;3L;3L;9L;-1L;8L;3L;-1L;7L;-9L;0L;-6L;-8L|];[|7L;-1L;8L;-4L;4L;1L;2L;-7L;7L;-6L;-5L;-8L;7L;-6L;0L;-9L|];[|7L;9L;9L;1L;3L;2L;-5L;8L;7L;-6L;3L;0L;1L;-8L;-9L;0L|]|] |> should equal 132L
