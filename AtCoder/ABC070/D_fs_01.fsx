// https://atcoder.jp/contests/abc070/submissions/7972972
[<AutoOpen>]
module Program

open System

let read f = stdin.ReadLine() |> f
let reada f = stdin.ReadLine().Split() |> Array.map f
let reads f = stdin.ReadLine().Split() |> Array.toList |> List.map f

let INF = 100000000000000L

let makeGraph N es =
    let g = Array.init (N + 1) (fun _ -> [])
    for [a; b; c] in es do
        g.[a] <- (b, c) :: g.[a]
        g.[b] <- (a, c) :: g.[b]
    g

let dijkstra N K (g: (int * int) list []) =
    let d = Array.create (N + 1) INF
    d.[K] <- 0L
    let mutable q = Set.singleton (0L, K)

    let rec loop () =
        if not (Set.isEmpty q) then
            let (c', v) = Set.minElement q
            q <- Set.remove (c', v) q

            if int64 c' <= d.[v] then
                let es = g.[v]
                for b, c in es do
                    let s = d.[v] + int64 c
                    if s < d.[b] then
                        d.[b] <- s
                        q <- Set.add (s, b) q

            loop ()
    loop ()

    d

[<EntryPoint>]
let main _ =
    let N = read int
    let abcs = List.init (N - 1) (fun _ -> reads int)
    let [Q;K] = reads int
    let xys = List.init Q (fun _ -> reads int)

    let graph = makeGraph N abcs
    let dijk = dijkstra N K graph

    for [x; y] in xys do
        printfn "%i" (dijk.[x] + dijk.[y])

    0
