// https://atcoder.jp/contests/abc172/tasks/abc172_c
// https://atcoder.jp/contests/abc172/submissions/14755527
// 未調整
let rec solve: int64 -> int64 -> int64 array -> int64 array -> int64 array =
    fun k l xs ys ->
        match xs, ys with
        | [||], _ -> [| 0L |]
        | _, [||] -> [| 0L |]
        | _, _ ->
            if (xs |> Array.head) + (ys |> Array.head) <= k
            then Array.append [| l |] (solve k (l + 1L) xs (ys |> Array.tail))
            else solve k (l - 1L) (xs |> Array.tail) ys

let judge k a b =
    let aScanK =
        a
        |> Array.scan (+) 0L
        |> Array.takeWhile (fun x -> x <= k)

    let bScanK =
        b
        |> Array.scan (+) 0L
        |> Array.takeWhile (fun x -> x <= k)

    let ansA =
        solve k ((a.Length |> int64) - 1L) (aScanK |> Array.rev) bScanK
        |> Array.max

    let ansB =
        solve k ((b.Length |> int64) - 1L) (bScanK |> Array.rev) aScanK
        |> Array.max

    max ansA ansB

//let inputs = System.IO.File.ReadAllLines @"ABC172/CSample1.txt" |> Array.map (fun s -> s.Split(" ")) |> Array.map (Array.map int64)
//let files = [| "ABC172/CSample1.txt"; "ABC172/CSample2.txt"; "ABC172/CSample3.txt" |]
//let input = System.IO.File.ReadAllLines >> Array.map ((fun s -> s.Split(" ")) >> Array.map int64)
//input files.[0]
//for f in files do (input f |> (fun [|[|n;m;k|]; a; b|] -> judge k a b |> printfn "%A"))
//let inputs = System.IO.File.ReadAllLines @"ABC172/CSample1.txt" |> Array.map ((fun s -> s.Split(" ")) >> Array.map int64)
// expected: 3; 7; 0

[<EntryPoint>]
let main argv =
    let _, _, k =
        stdin.ReadLine().Split()
        |> fun x -> x.[0], x.[1], x.[2] |> int64

    let a =
        stdin.ReadLine().Split() |> Array.map int64

    let b =
        stdin.ReadLine().Split() |> Array.map int64

    0
