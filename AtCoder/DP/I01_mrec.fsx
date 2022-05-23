#r "nuget: FsUnit"
open FsUnit
let N,Pa = 3,[|0.30;0.60;0.80|]
"""TLE
cf. https://atcoder.jp/contests/dp/submissions/28071011
https://stackoverflow.com/questions/3459422/combine-memoization-and-tail-recursion
継続渡しで末尾再帰にすれば速くなる?
"""
let solve N (Pa:float[]) =
    let memorec f =
        let memo = System.Collections.Generic.Dictionary<_,_>()
        let rec frec j =
            match memo.TryGetValue j with
                | exist, value when exist -> value
                | _ -> let value = f frec j in memo.Add(j, value); value
        frec
    let rec f frec (i,j) =
        match (i,j) with
        | (0,0) -> 1.0
        | _ when i < j -> 0.0
        | (_,0) -> frec (i-1,j)*(1.0 - Pa.[i-1])
        | _     -> frec (i-1,j)*(1.0 - Pa.[i-1]) + frec (i-1,j-1)*Pa.[i-1]
    let g = memorec f
    Array.init (N+1) (fun j -> if N-j<j then g (N,j) else 0.0) |> Array.sum
let N = stdin.ReadLine() |> int
let Pa = stdin.ReadLine().Split() |> Array.map float
solve N Pa |> stdout.WriteLine

let near0 x y = (abs (x-y)) < 0.000_000_000_1
near0 (solve 3 [|0.30;0.60;0.80|]) 0.612 |> should be True
near0 (solve 1 [|0.50|]) 0.5 |> should be True
near0 (solve 5 [|0.42;0.01;0.42;0.99;0.42|]) 0.382_181_587_2 |> should be True
