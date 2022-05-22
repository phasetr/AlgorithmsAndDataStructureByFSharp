#r "nuget: FsUnit"
open FsUnit

let N,K,Ha = 5,3,[|10;30;40;50;20|]
@"https://atcoder.jp/contests/dp/submissions/18241458"
let solve N K (Ha: array<int>) =
    let memorec f =
        let memo = System.Collections.Generic.Dictionary<_, _>()
        let rec frec j =
            match memo.TryGetValue j with
            | exist, value when exist -> value
            | _ -> let value = f frec j in memo.Add(j, value); value
        frec
    let dpf frec i =
        if i = 0 then 0
        else
            let k = max (i-K) 0
            {k..i-1} |> Seq.map (fun j -> abs (Ha.[j] - Ha.[i]) + frec j) |> Seq.min
    (memorec dpf) (N-1)

let N, K = stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0], x.[1]
let Ha = stdin.ReadLine().Split() |> Array.map int
solve N K Ha |> stdout.WriteLine

solve 5 3 [|10;30;40;50;20|] |> should equal 30
solve 3 1 [|10;20;10|] |> should equal 20
solve 2 100 [|10;10|] |> should equal 0
solve 10 4 [|40;10;20;70;80;10;20;70;80;60|] |> should equal 40
