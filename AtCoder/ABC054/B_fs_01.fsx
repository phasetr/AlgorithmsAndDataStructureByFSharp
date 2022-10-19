// https://atcoder.jp/contests/abc054/submissions/2697475
open System
open System.Collections.Generic
open System.Linq
open System

let Puts = Console.WriteLine : 'a -> unit
let Reads () = Console.ReadLine().Split()
let ReadDouble () = Reads() |> (fun x -> x.[0], x.[1])
let ReadTriple () = Reads() |> (fun x -> x.[0], x.[1], x.[2])
let ReadQuadruple () = Reads() |> (fun x -> x.[0], x.[1], x.[2], x.[3])

let FuncDouble f1 f2 (t1, t2) = (f1 t1, f2 t2)
let FuncTriple f1 f2 f3 (t1, t2, t3) = (f1 t1, f2 t2, f3 t3)
let FuncQuadruple f1 f2 f3 f4 (t1, t2, t3, t4) = (f1 t1, f2 t2, f3 t3, f4 t4)

let ensmallen l = l % 1000000007L

// main code


let (n, m) = ReadDouble() |> FuncDouble int int


let bigger = seq { for _ in 1..n -> Console.ReadLine() } |> List.ofSeq
let smaller = [1..m] |> Seq.map (fun _ -> Console.ReadLine()) |> List.ofSeq

let isSameImage(i, j) =
    let bImage = bigger.[i..i+m-1] |> Seq.collect (fun s -> s.[j..j+m-1]) |> Array.ofSeq |> String
    let sImage = smaller |> Seq.concat |> Array.ofSeq |> String
    bImage = sImage

let b = seq { for i in 0..n-m do for j in 0..n-m -> i, j } |> Seq.exists isSameImage
if b then Puts "Yes" else Puts "No"
