#r "nuget: FsUnit"
open FsUnit

let H,W,N,Xa = 3,4,2,[|(2,2);(1,4)|]
let M = 1_000_000_007L
let inline (%%) n m = let k = n%m in if sign k >= 0 then k else abs m + k
let factorial n =
    let mutable fact    = Array.append [|1L;1L|] (Array.zeroCreate (n-1))
    let mutable factinv = Array.append [|1L;1L|] (Array.zeroCreate (n-1))
    let mutable inv     = Array.append [|0L;1L|] (Array.zeroCreate (n-1))
    for i in 2..n do
        fact.[i] <- (fact.[i-1] * (int64 i)) %% M
        inv.[i] <- (- inv.[(int M)%i] * (M/(int64 i))) %% M
        factinv.[i] <- factinv.[i-1] * inv.[i] %% M
    fact,factinv,inv
let solve H W N Xa =
    let h,w = H-1,W-1
    let Ya = Array.map (fun (r,c) -> r-1,c-1) Xa |> Array.sortBy (fun (r,c) -> r+c)

    let fact,factinv,inv = factorial (h+w)
    let comb n r =
        if r<0 || n<r then 0L
        else ((fact.[n] * factinv.[r] % M) * factinv.[n-r]) %% M

    let mutable dp:int64[] = Array.zeroCreate N
    for i in 0..N-1 do
        let x,y = Ya.[i]
        dp.[i] <- comb (x+y) y
        for j in 0..i-1 do
            let x0,y0 = Ya.[j]
            dp.[i] <- (dp.[i] - dp.[j] * (comb (x+y-(x0+y0)) (x-x0))) %% M
    let mutable ans = comb (h+w) h
    for i in 0..N-1 do
        let x,y = Ya.[i]
        ans <- (ans - dp.[i] * comb (h+w-(x+y)) (h-x)) %% M
    ans
let H,W,N = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1], x.[2])
let Xa = [| for i in 1..N do (stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1]) |]
solve H W N Xa |> stdout.WriteLine

solve 3 4 2 [|(2,2);(1,4)|] |> should equal 3L
