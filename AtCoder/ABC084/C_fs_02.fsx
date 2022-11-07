// https://atcoder.jp/contests/abc084/submissions/1925534
// Try AtCoder
// author: Leonardone @ NEETSDKASU

let time t s f =
    if t < s then
        s
    elif t % f = 0 then
        t
    else
        t + f - (t % f)

let rec calc t xs =
    match xs with
    | []    -> t
    | [|c; s; f|]::xs ->
        let u = time t s f
        calc (u + c) xs

let rec solve n xs =
    match xs with
    | [] -> []
    | [|c; s; _|]::xs ->
        calc (c + s) xs :: solve n xs

[<EntryPoint>]
let main _ =
    let n = int <| stdin.ReadLine()
    let xs =
        seq { 1 .. n - 1 }
        |> Seq.map (fun _ ->
            stdin.ReadLine().Split(' ')
            |> Array.map int
            )
        |> Seq.toList
    solve n xs
    |> Seq.iter (fun x -> printfn "%A" x)
    printfn "0"
    0
