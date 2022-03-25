@"https://atcoder.jp/contests/abc143/submissions/8054845"
#r "nuget: FsUnit"
open FsUnit

let solve n (ls:array<int>) =
    let memoize fn =
        let cache = new System.Collections.Generic.Dictionary<_,_>()
        (fun x ->
            match cache.TryGetValue x with
            | true, v -> v
            | _ ->
                let v = fn (x)
                cache.Add(x,v)
                v)

    let sorted = ls |> Array.sort
    let searchC sum =
        sorted |> Array.tryFindIndex (fun x -> x >= sum)
        |> fun i ->
            match i with
                | None -> n-1
                | Some i -> i-1
    let memSearchC = memoize searchC

    seq {
        for i in 0..n-3 do
        for j in i+1..n-2 do
            yield sorted.[i], sorted.[j], j
    }
    |> Seq.map (fun (a,b,i) -> (memSearchC (a+b), i))
    |> Seq.map (fun (x, y) -> x - y)
    |> Seq.sum

let n = stdin.ReadLine() |> int
let ls = stdin.ReadLine().Split() |> Array.map int
solve n ls |> stdout.WriteLine

solve 4 [|3;4;2;1|] |> should equal 1
solve 3 [|1;1000;1|] |> should equal 0
solve 7 [|218;786;704;233;645;728;389|] |> should equal 23
