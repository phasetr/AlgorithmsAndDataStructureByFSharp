// https://atcoder.jp/contests/abc173/tasks/abc173_b
let classify (acc: int array) =
    function
    | "AC" ->
        acc.[0] <- acc.[0] + 1
        acc
    | "WA" ->
        acc.[1] <- acc.[1] + 1
        acc
    | "TLE" ->
        acc.[2] <- acc.[2] + 1
        acc
    | _ ->
        acc.[3] <- acc.[3] + 1
        acc

let rec solve (acc: int array) s =
    match s with
    | [] -> acc
    | x :: xs ->
        let accNew = classify acc x
        solve accNew xs

[<EntryPoint>]
let main argv =
    let n = stdin.ReadLine() |> int

    let s =
        seq {
            for i in 1 .. n do
                stdin.ReadLine()
        }
        |> List.ofSeq

    let acc = solve [| 0; 0; 0; 0 |] s
    printfn "AC x %d" acc.[0]
    printfn "WA x %d" acc.[1]
    printfn "TLE x %d" acc.[2]
    printfn "RE x %d" acc.[3]
    0
