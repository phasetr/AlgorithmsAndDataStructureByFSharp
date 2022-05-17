#r "nuget: FsUnit"
open FsUnit

let N,Ha = 4,[|10;30;40;20|]
let solve N (Ha:int[]) =
    let memorec f =
        let memo = System.Collections.Generic.Dictionary<_,_>()
        let rec frec j =
            match memo.TryGetValue j with
                | exist, value when exist -> value
                | _ -> let value = f frec j in memo.Add(j, value); value
        frec
    let dpf frec = function
        | 0 -> 0
        | 1 -> abs (Ha.[1] - Ha.[0])
        | i -> min (frec(i-1) + abs (Ha.[i]-Ha.[i-1])) (frec(i-2) + abs (Ha.[i]-Ha.[i-2]))
    (memorec dpf) (N-1)
let N = stdin.ReadLine() |> int
let Ha = stdin.ReadLine().Split() |> Array.map int
solve N Ha |> stdout.WriteLine

solve 4 [|10;30;40;20|] |> should equal 30
solve 2 [|10;10|] |> should equal 0
solve 6 [|30;10;60;10;60;50|] |> should equal 40
