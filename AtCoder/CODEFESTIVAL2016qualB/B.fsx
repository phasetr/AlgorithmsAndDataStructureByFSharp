// https://atcoder.jp/contests/code-festival-2016-qualb/tasks/codefestival_2016_qualB_b
type Count = { A: int; B: int }
let rec check a b s count result =
    match s with
    | [] -> result
    | x :: xs ->
        if x = 'c' then check a b xs { A = count.A; B = count.B } ("No" :: result)
        elif x = 'a' then
            if count.A + count.B < a + b
            then check a b xs { A = count.A + 1; B = count.B } ("Yes" :: result)
            else check a b xs { A = count.A; B = count.B } ("No" :: result)
        else
            if (count.A + count.B < a + b) && count.B < b
            then check a b xs { A = count.A; B = count.B + 1 } ("Yes" :: result)
            else check a b xs { A = count.A; B = count.B } ("No" :: result)

let fc a b s = check a b (Seq.toList s) { A = 0; B = 0 } [] |> List.rev

//let input = [| (10, 2, 3, "abccabaabb"); (12, 5, 2, "cabbabaacaba"); (5, 2, 2, "ccccc") |]
//for (n, a, b, s) in input do (fc a b s |> List.map (printfn "%A"))

[<EntryPoint>]
let main argv =
    let inputFst = stdin.ReadLine().Split(' ') |> Array.map int
    let n = inputFst.[0]
    let a = inputFst.[1]
    let b = inputFst.[2]
    let s = stdin.ReadLine()
    fc a b s |> List.map (printfn "%s") |> ignore
    0
