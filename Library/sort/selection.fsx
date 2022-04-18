#r "nuget: FsUnit"
open FsUnit

// https://qiita.com/Tatsuki-I/items/66d1f5186348aaa9b537
module SelectionByUnfold =
    // let rec deleteAll x = function
    //     | [] -> []
    //     | y :: ys -> if x = y then ys else y :: deleteAll x ys
    let deleteAll x = List.filter ((<>) x)
    let sepMin = function
        | [] -> None
        | xs ->
            let y = List.min xs
            let ys = deleteAll y xs
            Some(y, ys)
    let ssort xs = List.unfold sepMin xs
    ssort [7;3;2;1;4;5] |> should equal [1;2;3;4;5;7]
