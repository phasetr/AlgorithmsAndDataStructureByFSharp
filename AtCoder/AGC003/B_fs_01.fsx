// https://atcoder.jp/contests/agc003/submissions/10537751
open System
open System.Collections.Generic

[<AutoOpen>]
module Cin =
    let read f = stdin.ReadLine() |> f
    let reada f = stdin.ReadLine().Split() |> Array.map f
    let readChars() = read string |> Seq.toArray
    let readInts() = readChars() |> Array.map (fun x -> Convert.ToInt32(x.ToString()))

[<AutoOpen>]
module Cout =
    let writer = new IO.StreamWriter(new IO.BufferedStream(Console.OpenStandardOutput()))
    let print (s: string) = writer.Write s
    let println (s: string) = writer.WriteLine s
    let inline puts (s: ^a) = string s |> println

// -----------------------------------------------------------------------------------------------------

// -----------------------------------------------------------------------------------------------------

let main() =
    let N = read int
    let A = Array.zeroCreate (N + 1)
    for i in 0 .. N - 1 do
        let a = read int64
        A.[i] <- a

    let mutable ans = 0L
    for i in 0 .. N - 1 do
        let a = A.[i] / 2L
        ans <- ans + a
        A.[i] <- A.[i] % 2L
        if A.[i] > 0L && A.[i + 1] > 0L then
            ans <- ans + 1L
            A.[i] <- A.[i] - 1L
            A.[i + 1] <- A.[i + 1] - 1L

    puts ans
    ()

// -----------------------------------------------------------------------------------------------------
main()
writer.Dispose()
