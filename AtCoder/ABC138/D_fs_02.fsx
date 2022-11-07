// https://atcoder.jp/contests/code-festival-2016-qualc/tasks/codefestival_2016_qualC_b
let [|N;Q|] = stdin.ReadLine().Split() |> Array.map int

let Pass = [|for i in 1..N-1 -> stdin.ReadLine().Split() |> Array.map int |> Array.map (fun x -> x-1)|]
let query = [|for i in 1..Q -> stdin.ReadLine().Split() |> Array.map int |> Array.map (fun x -> x-1)|]

let mutable To = [|for i in 1..N -> []|]
let mutable point = [|for i in 1..N -> 0|]
let mutable seen = [|for i in 1..N -> true|]

let rec dfs index =
    do
        for i in To.[index] do
            if seen.[i]
            then
                seen.[i] <- not seen.[i]
                point.[i] <- point.[i] + point.[index]
                dfs i

for i in Pass do
    To.[i.[0]] <- i.[1] :: To.[i.[0]]
    To.[i.[1]] <- i.[0] :: To.[i.[1]]

for i in query do
    point.[i.[0]] <- point.[i.[0]] + i.[1] + 1

seen.[0] <- false
dfs 0

for i in 0..N-2 do
    printf "%d " point.[i]
printfn "%d" point.[N-1]
