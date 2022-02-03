@"https://atcoder.jp/contests/abc151/tasks/abc151_c"
#r "nuget: FsUnit"
open FsUnit

let calcSolved gs =
    let isSolved ps = ps |> Array.exists (fun s -> s = "AC")

    gs |> Array.map (fun (_, ps) -> isSolved ps)
    |> Array.filter id
    |> Array.length

let calcPenalties gs =
    let calcEachPenalties (rs: array<string>): int =
        rs |> Array.fold (fun (acc, b) r ->
            if b then (acc, b)
            else if r = "AC" then (acc, true) else (acc+1, false))
            (0, false)
        |> fun (acc, b) -> if b then acc else 0

    gs |> Array.fold (fun acc (_,rs) -> acc + calcEachPenalties rs) 0

let solve N M pss =
    let gs =
        pss
        |> Array.groupBy (fun (p,_) -> p)
        |> Array.map (fun (p, ps) -> (p, Array.map (fun (_, s) -> s) ps))
    let solved = calcSolved gs
    let penalties = calcPenalties gs
    (solved, penalties)

let N, M = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
let pss = [| for i in 1..M do (stdin.ReadLine().Split() |> fun x -> (int x.[0], x.[1])) |]
solve N M pss |> fun (a,b) -> printfn "%d %d" a b

solve 2 5 [|(1,"WA");(1,"AC");(2,"WA");(2,"AC");(2,"WA")|] |> should equal (2,2)
solve 100000 3 [|(7777,"AC");(7777,"AC");(7777,"AC")|] |> should equal (1,0)
solve 6 0 [||] |> should equal (0,0)
