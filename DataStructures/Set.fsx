// Rabhi-Lapalme P.93
module SetByListWithDuplicates =
    type 'a Set = { Set: 'a list }
    let emptySet = { Set = [] }

    let setEmpty =
        function
        | { Set = [] } -> true
        | _ -> false

    let inSet x xs =
        match xs with
        | { Set = [] } -> false
        | { Set = ss } -> List.contains x ss

    let addSet x ({ Set = xs }) = { Set = x :: xs }

    let delSet x ({ Set = xs }) = { Set = List.filter ((<>) x) xs }

// test
open SetByListWithDuplicates

emptySet |> printfn "%A"
emptySet |> setEmpty |> printfn "%A"
emptySet |> addSet 1 |> printfn "%A"

let set = emptySet |> addSet 1 |> addSet 1 |> addSet 2 |> addSet 3
set |> delSet 10 |> printfn "%A"
set |> delSet 1 |> printfn "%A"
set |> delSet 2 |> printfn "%A"
set |> inSet 2 |> printfn "%A"
set |> inSet 10 |> printfn "%A"
