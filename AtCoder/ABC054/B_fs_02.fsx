// https://atcoder.jp/contests/abc054/submissions/1122842
module Main

open System

let nm =
    Console.ReadLine().Split(' ')
        |> Array.map int

let ss =
    [ for _ in 1..nm.[0] ->
        [for c in Console.ReadLine() -> c]
    ]

let bs =
    [ for _ in 1..nm.[1] ->
        [for c in Console.ReadLine() -> c]
    ]

let rec prefix xxs yys =
    (xxs, yys) |> function
        | (x :: xs, y :: ys) when x = y -> prefix xs ys
        | ([], _) -> true
        | _ -> false

let rec zip xxs yys =
    (xxs, yys) |> function
        | (x :: xs), (y :: ys) -> (x, y) :: zip xs ys
        | _ -> []

let solve c xs =
    let rec reccolf n ys =
        if n = 0 then
            false
        elif List.forall (fun (b, x) -> prefix b x) <| zip bs ys then
            true
        else
            reccolf (n - 1) <| List.map List.tail ys

    let rec recf n ys =
        if n = 0 then
            false
        elif reccolf c ys then
            true
        else
            recf (n - 1) <| List.tail ys

    recf c xs

Console.WriteLine(
    if solve (nm.[0] - nm.[1] + 1) ss then
        "Yes"
    else
        "No"
)
