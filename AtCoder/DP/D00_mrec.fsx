@"https://atcoder.jp/contests/dp/tasks/dp_d"
#r "nuget: FsUnit"
open FsUnit

let N,W,wva = 3,8,[|(3,30L);(4,50L);(5,60L)|]
let solve N W (wva: array<int*int64>) =
    let memorec f =
        let memo = System.Collections.Generic.Dictionary<_,_>()
        let rec frec j =
            match memo.TryGetValue j with
                | exist, value when exist -> value
                | _ -> let value = f frec j in memo.Add(j, value); value
        frec

    let rec dpf frec i =
        let (wi,vi) = wva.[i]
        [|0..W|]
        |> Array.map (fun w ->
            if i=0 then if (wi > w) then 0L else vi
            else
                if w >= wi then let wa:int64[] = frec (i-1) in max wa.[w] (wa.[w-wi] + vi)
                else Array.get (frec (i-1)) w)
    (memorec dpf) (N-1) |> Array.last
let N,W = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
let wva = [| for i in 1..N do (stdin.ReadLine().Split() |> fun x -> int x.[0], int64 x.[1]) |]
solve N W wva |> stdout.WriteLine

solve 3 8 [|(3,30L);(4,50L);(5,60L)|] |> should equal 90L
solve 5 5 [|(1,1000000000L);(1,1000000000L);(1,1000000000L);(1,1000000000L);(1,1000000000L)|] |> should equal 5000000000L
solve 6 15 [|(6,5L);(5,6L);(6,4L);(6,6L);(3,5L);(7,2L)|] |> should equal 17L
