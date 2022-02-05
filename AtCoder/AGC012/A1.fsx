@"https://atcoder.jp/contests/agc012/tasks/agc012_a"
#r "nuget: FsUnit"
open FsUnit

let solve0 N As =
    let Bs = As |> Array.sort
    [|(3*N-2)..(-2)..(N-1)|]
    |> Array.fold (fun acc i -> acc + Bs.[i]) 0L

let solve N As =
    let Bs = As |> Array.sortDescending
    [|1..2..(2*N-1)|]
    |> Array.fold (fun acc i -> acc + Bs.[i]) 0L
let N = stdin.ReadLine() |> int
let As = stdin.ReadLine().Split() |> Array.map int64
solve N As |> stdout.WriteLine

let stoi (s: string) = s.Split(" ") |> Array.map int
let sstois (s: string) = s.Split("\n") |> Array.map stoi

solve 2 [|5L;2L;8L;5L;1L;5L|] |> should equal 10L
solve 10 [|1000000000L;1000000000L;1000000000L;1000000000L;1000000000L;1000000000L;1000000000L;1000000000L;1000000000L;1000000000L;1000000000L;1000000000L;1000000000L;1000000000L;1000000000L;1000000000L;1000000000L;1000000000L;1000000000L;1000000000L;1000000000L;1000000000L;1000000000L;1000000000L;1000000000L;1000000000L;1000000000L;1000000000L;1000000000L;1000000000L|] |> should equal 10000000000L
