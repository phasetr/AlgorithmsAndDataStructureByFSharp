// https://atcoder.jp/contests/keyence2020/submissions/35235429
open System
open System.Collections.Generic

let read t =
    stdin.ReadLine() |> t

let readA t =
    stdin.ReadLine().Split() |> Array.map t

let solve () =
    let N = read int
    let AB = [
        for _ in 1..N do
        let [|X; L|] = readA int
        max 0 (X-L), (X+L)
    ]
    let count ab =
        let rec loop cnt right l =
            match l with
            | [] -> cnt
            | (a, b) :: rest ->
                if right <= a then loop (cnt+1) b rest
                else loop cnt right rest
        loop 0 0 ab
    List.sortBy (fun (_,b) -> b) AB |> count


solve() |> Console.WriteLine
