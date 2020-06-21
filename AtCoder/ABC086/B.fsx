// https://atcoder.jp/contests/abc086/tasks/abc086_b
// [| "12"; "34" |] |> String.concat "" |> int -> 1234
let rec isSquare acc num =
    if num = acc * acc then true
    elif num < acc * acc then false
    else isSquare (acc + 1) num

//for i in [| 121; 100100; 1210 |] do (isSquare i 4 |> printfn "%b")

[<EntryPoint>]
let main argv =
    stdin.ReadLine().Split(' ')
    |> String.concat ""
    |> int
    |> isSquare 4 // 1 以上の数を連結しているから 3^2=9以下は考えなくていい
    |> fun x -> if x then "Yes" else "No"
    |> printfn "%s"

    0
