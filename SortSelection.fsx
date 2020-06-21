// https://qiita.com/Tatsuki-I/items/66d1f5186348aaa9b537
module SelectionByUnfold =
    /// Delete only first one element
    let rec delete x xs =
        match xs with
        | [] -> []
        | y :: ys -> if x = y then ys else y :: delete x ys

    let deleteAll x = List.filter ((<>) x)

    let separateMinimum =
        function
        | [] -> None
        | xs ->
            let y = List.min xs
            let ys = delete y xs
            Some(y, ys)

    let selectionSort = List.unfold separateMinimum

// test
SelectionByUnfold.selectionSort [ 7; 3; 2; 1; 4; 5 ]
|> printfn "%A"
