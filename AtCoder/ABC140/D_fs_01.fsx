// https://atcoder.jp/contests/abc140/submissions/7510897
let reads f = stdin.ReadLine().Split() |> Array.map f
let count xs =
    let rec loop ys i =
        match ys with
        | [] | [_] -> i
        | h::hs when h <> hs.[0] -> loop hs (i+1)
        | _::hs -> loop hs i
    loop xs 0
let (n,k) = reads int |> fun x -> x.[0],x.[1]
let s = (stdin.ReadLine()).ToCharArray() |> Array.toList
n - 1 + (min 0 (2*k-(count s)))
|> printfn "%d"
