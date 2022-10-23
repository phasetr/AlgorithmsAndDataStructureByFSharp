// https://atcoder.jp/contests/abc142/submissions/7782610
let [| a; b; |] = stdin.ReadLine().Split() |> Array.map int64

let gcd a b =
    let rec f a b=
        let a, b =
            if a < b then  b, a
            else a, b
        match a % b with
        | 0L -> min a b
        | x -> f (min a b) x
    f a b

let factorization n =
    if n = 1L then Set.empty
    else
    let rec f (i:int64) nTmp (result:Set<_>)=
        match nTmp % i , i * i > nTmp with
        | _, true -> result.Add(nTmp)
        | 0L, _ -> f i (nTmp/i) (result.Add(i))
        | _, _ -> f (i+1L) nTmp result
    f 2L n Set.empty

(gcd a b |>factorization |> Set.count) + 1 |> stdout.WriteLine
