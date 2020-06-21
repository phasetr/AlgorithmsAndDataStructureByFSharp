// https://atcoder.jp/contests/abc157/tasks/abc157_b
[<EntryPoint>]
let main argv =
    let a: int [,] = Array2D.zeroCreate 3 3
    let checks = Array2D.create 3 3 false
    let index = [| 0; 1; 2 |]

    let a0 =
        stdin.ReadLine().Split(' ') |> Array.map int

    index |> Array.iter (fun i -> a.[0, i] <- a0.[i])

    let a1 =
        stdin.ReadLine().Split(' ') |> Array.map int

    index |> Array.iter (fun i -> a.[1, i] <- a1.[i])

    let a2 =
        stdin.ReadLine().Split(' ') |> Array.map int

    index |> Array.iter (fun i -> a.[2, i] <- a2.[i])

    let n = stdin.ReadLine() |> int
    let b = Array.zeroCreate n
    for i in [ 0 .. n - 1 ] do
        b.[i] <- (stdin.ReadLine() |> int)

    a
    |> Array2D.iteri (fun i j v1 ->
        b
        |> Array.iteri (fun k v2 -> if v1 = v2 then checks.[i, j] <- true else ()))

    (Array.reduce (&&) (index |> Array.map (fun i -> checks.[0, i]))
     || Array.reduce (&&) (index |> Array.map (fun i -> checks.[1, i]))
     || Array.reduce (&&) (index |> Array.map (fun i -> checks.[2, i]))
     || Array.reduce (&&) (index |> Array.map (fun i -> checks.[i, 0]))
     || Array.reduce (&&) (index |> Array.map (fun i -> checks.[i, 1]))
     || Array.reduce (&&) (index |> Array.map (fun i -> checks.[i, 2]))
     || Array.reduce (&&) (index |> Array.map (fun i -> checks.[i, i]))
     || Array.reduce (&&) (index |> Array.map (fun i -> checks.[2 - i, i])))
    |> fun x -> if x then "Yes" else "No"
    |> printfn "%s"

    0
