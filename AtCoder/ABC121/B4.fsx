// https://atcoder.jp/contests/abc121/tasks/abc121_b
// https://atcoder.jp/contests/abc121/submissions/6356059
type ABC(stream: System.IO.TextReader) =
    member this.Scan1 f = stream.ReadLine() |> f

    member this.Scan2 f =
        stream.ReadLine().Split()
        |> Array.map f
        |> (fun a -> (a.[0], a.[1]))

    member this.Scan3 f =
        stream.ReadLine().Split()
        |> Array.map f
        |> (fun a -> (a.[0], a.[1], a.[2]))

    member this.Scan4 f =
        stream.ReadLine().Split()
        |> Array.map f
        |> (fun a -> (a.[0], a.[1], a.[2], a.[3]))

    member this.ScanVecH f = stream.ReadLine().Split() |> Array.map f
    member this.ScanVecV n f = [| for i in 1 .. n -> stream.ReadLine() |> f |]

    member this.ScanMatrix n f =
        [ for i in 1 .. n do
            yield stream.ReadLine().Split() |> Array.map f ]

    member this.ScanCharMatrix n = [| for i in 1 .. n -> stream.ReadLine().ToCharArray() |]
    member this.Close() = stream.Close()

let util = ABC(stdin)

let N, M, C = util.Scan3 int
let As = util.ScanVecH int
let Bs = util.ScanMatrix N int

let isOK arr =
    Array.map2 (*) As arr
    |> Array.sum
    |> fun x -> (x + C) > 0

Bs
|> List.filter isOK
|> List.length
|> printfn "%d"
