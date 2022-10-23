// https://atcoder.jp/contests/abc142/submissions/34082293
let A,B = stdin.ReadLine().Split(' ') |> Array.map int64 |> fun x -> x.[0],x.[1]

let rec gcd x y =
    match y with
    |0L -> x
    |_ -> gcd y (x % y)

let N = gcd A B
let rec primarys (list:int64 list) i n =
    match i,n with
    | _,n when n <= 1L -> list
    | i,n when n < i * i -> n::list
    | i,n when n % i = 0L -> primarys (i::list) i (n/i)
    | _ -> primarys list (i+1L) n

let ans =
    primarys [] 2L N
    |> List.distinct
    |> List.length
    |> (+) 1


printfn "%i" ans
