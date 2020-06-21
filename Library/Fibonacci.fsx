(*
メモ化していない重いフィボナッチ
*)

let rec fibNoMemo n =
    if n = 0I then 0I
    else if n = 1I then 1I
    else fibNoMemo (n - 1I) + fibNoMemo (n - 2I)

//fibNoMemo 5I

(*
メモ化したフィボナッチ
*)

#nowarn "40"

let rec fibMemo =
    let dict =
        System.Collections.Generic.Dictionary<_, _>()

    fun n ->
        match dict.TryGetValue(n) with
        | true, v -> v
        | false, _ ->
            let temp =
                if n = 0I then 0I
                else if n = 1I then 1I
                else fibMemo (n - 1I) + fibMemo (n - 2I)

            dict.Add(n, temp)
            temp

//fibMemo 50I

(*
unfold によるフィボナッチ数列
https://docs.microsoft.com/ja-jp/dotnet/fsharp/language-reference/sequences
*)

/// UntilN とあるが、実際には最終項が N を超えたところでようやく止まる
/// 実際に実行してみるとわかる
let fibByUnfoldUntilN n =
    (1, 1) // Initial state
    |> Seq.unfold (fun state ->
        if (snd state > n)
        then None
        else Some(fst state + snd state, (snd state, fst state + snd state)))

//fibByUnfoldUntilN 1000 |> List.ofSeq |> printfn "%A"
//[2; 3; 5; 8; 13; 21; 34; 55; 89; 144; 233; 377; 610; 987; 1597]
