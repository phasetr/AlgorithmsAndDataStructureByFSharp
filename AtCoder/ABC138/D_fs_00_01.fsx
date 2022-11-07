// https://atcoder.jp/contests/abc138/submissions/34157793
open System
open System.Collections.Generic

let read t = stdin.ReadLine() |> t
let readA t = stdin.ReadLine().Split() |> Array.map t

let inline (+=) (l: byref<_>) r = l <- l + r

let solve N Q aba pxa =
  let mutable neighbors = [| for _ in 1..N -> ([]:list<int>) |]
  aba |> Array.iter (fun (a,b) ->
    neighbors.[a-1] <- b-1 :: neighbors.[a-1]
    neighbors.[b-1] <- a-1 :: neighbors.[b-1])
  let mutable counts: int[] = Array.zeroCreate N
  pxa |> Array.iter (fun (p,x) -> &counts.[p-1] += x)
  let rec dfs from v =
    printfn "%A" (from,v,counts)
    &counts.[v] += counts.[from]
    neighbors.[v] |> List.filter ((<>) from) |> List.iter (dfs v)
  neighbors.[0] |> List.iter (dfs 0)
  counts |> Array.toSeq |> Seq.map string |> String.concat " "

let [|N; Q|] = readA int
let aba = [| for i in 1..(N-1) do (stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1]) |]
let pxa = [| for i in 1..Q do (stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1]) |]
solve() |> Console.WriteLine
