// https://atcoder.jp/contests/abc147/submissions/8885675
[<AutoOpen>]
module Program

open System

let read f = stdin.ReadLine() |> f
let reads f = stdin.ReadLine().Split() |> Array.map f

[<EntryPoint>]
let main _ =
    let N = read int
    let AS =
        Array.init N (fun _ ->
            Array.init (read int) (fun _ -> reads int)
        )

    // 全探索
    let xss =
        let f xs = [0 :: xs; 1 :: xs]
        List.fold (<<) id (List.replicate N (List.collect f)) [[]]

    let f xs =
        let xs = List.toArray xs
        let mutable b = true
        Array.iteri (fun i ys ->
            if xs.[i] = 1 then
                for [|x; y|] in ys do
                    if xs.[x-1] <> y then
                        b <- false
        ) AS
        b

    List.filter f xss
    |> List.map List.sum
    |> List.max
    |> printfn "%i"

    0
