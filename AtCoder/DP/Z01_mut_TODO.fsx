#r "nuget: FsUnit"
open FsUnit

let N,C,Ha = 5,6L,[|1L;2L;3L;4L;5L|]
let solve N C Ha =
    let mutable ls = Array.append [|(-2L*Ha.[0], pown Ha.[0] 2)|] (Array.create N (0,0))
    let mutable I,J = 0,0

    for h in Ha.[1..] do
        let mutable u,v = ls.[I]
        while I < J do
            let w,y = ls.[I+1]
            if u*h+v >= w*h+y
            then
                u <- w
                v <- y
                I <- I+1
            printfn "(I,J): %A" (I,J)
        let mutable a = -2L*h
        let mutable b = u*h+v+2L*(pown h 2)+C
        while J > 0 do
            let (c,d) = ls.[J]
            let (e,f) = ls.[J-1]
            if (c-e)*(b-d) >= (d-f)*(a-c) then J <- J-1
            printfn "J: %A" J
        J <- J+1
        ls.[J] <- (a,b)
    u*h+v+h**2+C

let mutable a = 0
let mutable b = 0
if true then (a,b) <- (0,0)
pown 2L 2

let N,C = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
let Ha = stdin.ReadLine().Split() |> Array.map int64
solve N C Ha |> stdout.WriteLine

solve 5 6L [|1L;2L;3L;4L;5L|] |> should equal 20
solve 2 1000000000000L [|500000L;1000000L|]
solve 8 5L [|1L;3L;4L;5L;10L;11L;12L;13L|] |> should equal 62
