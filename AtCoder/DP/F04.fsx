// https://atcoder.jp/contests/dp/submissions/27052953
module StdIO =
    module Inner =
        let inline parse< ^a when ^a: (static member Parse : string -> ^a)> s =
            (^a: (static member Parse : string -> ^a) s)

    let inline parse () = stdin.ReadLine() |> Inner.parse

    let inline parseArray< ^a when ^a: (static member Parse : string -> ^a)> separator =
        stdin.ReadLine().Split separator
        |> Array.map Inner.parse< ^a>

module LCS =
    open System
    let inline cons l e = e :: l

    let createDp (s: string) (t: string) =
        let innerFolder (dp: _ []) j acc i =
            match i with
            | 0 -> 0 :: acc
            | i when s.[i - 1] = t.[j] -> (dp.[i - 1] + 1) :: acc
            | i -> (max dp.[i] (List.head acc)) :: acc

        let folder i dp j =
            let head = List.head dp

            ([], [ 0 .. i - 1 ])
            ||> List.fold (innerFolder head j)
            |> (List.rev >> List.toArray >> cons dp)

        let i = s.Length + 1
        let dp = [ Array.zeroCreate i ]

        (dp, { 0 .. t.Length - 1 })
        ||> Seq.fold (folder i)
        |> (List.rev >> List.toArray >> array2D)

    let traceback (s: string) (dp: _ [,]) =
        let rec loop i j =

            if dp.[i, j] = 0 then
                []
            elif dp.[i, j] = dp.[i - 1, j] then
                loop (i - 1) j
            elif dp.[i, j] = dp.[i, j - 1] then
                loop i (j - 1)
            else
                s.[i - 1] :: loop (i - 1) (j - 1)

        let i = Array2D.length1 dp - 1
        let j = Array2D.length2 dp - 1

        loop i j |> (List.rev >> List.toArray >> String)

    let solve s t = createDp s t |> traceback t


let f argv =
    let s = stdin.ReadLine()
    let t = stdin.ReadLine()
    LCS.solve s t |> printfn "%s"

[<EntryPoint>]
let main argv =
    f argv
    0
