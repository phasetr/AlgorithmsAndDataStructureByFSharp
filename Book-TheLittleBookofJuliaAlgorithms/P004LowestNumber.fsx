// P.004 LOWEST NUMBER
let p004Practice =
    printfn "はじめの数を整数で入力してください: "
    let num1 = stdin.ReadLine()
    printfn "2 番目の数を整数で入力してください: "
    let num2 = stdin.ReadLine()
    if num1 <= num2 then num1 else num2
    |> sprintf "最小の数（小さい方の数）は %A です。"
p004Practice |> printfn "%s"

// 変数 x が 4 から 7 の間にあることをチェックするコードを書け。
let p004Sol x =
    if 4 <= x && x <= 7 then true else false
[|1..9|] |> Array.map (fun x -> sprintf "%A: %A" x (p004Sol x)) |> printfn "%A"
