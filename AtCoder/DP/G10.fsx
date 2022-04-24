@""
#r "nuget: FsUnit"
open FsUnit

"以下のコードはTLEで使い物にならないので書き換えが必要"
let N,M,Aa = 4,5,[|(1,2);(1,3);(3,2);(2,4);(3,4)|]
let solve N M (Aa:array<int*int>) =
    let memorec f =
        let memo = System.Collections.Generic.Dictionary<_, _>()
        let rec frec j =
            match memo.TryGetValue j with
            | exist, value when exist -> value
            | _ -> let value = f frec j in memo.Add(j, value); value
        frec
    let g = [|0..N-1|] |> Array.map (fun s0 -> Aa |> Array.choose (fun (s,t) -> if s-1=s0 then Some (t-1) else None))
    let dp = memorec (fun dp v -> (0,g.[v]) ||> Array.fold (fun acc u -> max acc (1+dp u)))
    [|0..N-1|] |> Array.map dp |> Array.max
let N,M = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
let Aa = [| for i in 1..M do (stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1]) |]
solve N M Aa |> stdout.WriteLine

solve 4 5 [|(1,2);(1,3);(3,2);(2,4);(3,4)|] |> should equal 3
solve 6 3 [|(2,3);(4,5);(5,6)|] |> should equal 2
solve 5 8 [|(5,3);(2,3);(2,4);(5,2);(5,1);(1,4);(4,3);(1,3)|] |> should equal 3
