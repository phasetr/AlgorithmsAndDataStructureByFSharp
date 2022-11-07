// https://atcoder.jp/contests/abc138/submissions/7007874
[<AutoOpen>]
module Program

open System

let read f = stdin.ReadLine() |> f
let reada f = stdin.ReadLine().Split() |> Array.map f
let reads f = stdin.ReadLine().Split() |> Array.toList |> List.map f

[<EntryPoint>]
let main _ =
    let [n;q] = reads int
    let abs = List.init (n - 1) (fun _ -> reads int |> fun [a;b] -> (a, b))
    let pxs = List.init q (fun _ -> reads int |> fun [p;x] -> (p, x))

    let sumpx =
        let a = Array.create (n + 1) 0
        for (p, x) in pxs do
            a.[p] <- a.[p] + x
        a

    let grp =
        let g : int [] = Array.init (n + 1) (fun _ -> -1)
        for (a, b) in abs do
            g.[b] <- a
        g

    let ans = Array.create (n + 1) (-1)
    ans.[1] <- sumpx.[1]
    let rec loop i =
        let p = grp.[i]
        ans.[i] <- ans.[p] + sumpx.[i]

    for i = 2 to n do loop i

    printf "%i" ans.[1]
    for i = 2 to n do
        printf " %i" ans.[i]

    0
