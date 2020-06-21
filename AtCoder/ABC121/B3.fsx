// https://atcoder.jp/contests/abc121/tasks/abc121_b
// https://atcoder.jp/contests/abc121/submissions/6794419
let reads f =
    stdin.ReadLine().Split()
    |> Array.toList
    |> List.map f

[<EntryPoint>]
let main argv =
    let n, c = reads int |> fun x -> x.[0], x.[2]
    let bs = reads int
    let ass = List.map (fun _ -> reads int) [ 1 .. n ]
    seq {
        for xs in ass do
            let ab = List.map2 (*) bs xs |> List.sum
            if ab + c > 0 then yield ()
    }
    |> Seq.length
    |> printfn "%i"
    0
