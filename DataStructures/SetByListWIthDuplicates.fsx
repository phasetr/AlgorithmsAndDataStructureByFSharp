(*
Rabhi-Lapalme P.93
We can easily implement `addSet` but `delSet` requires to check the whole list,
which is expensive.
*)
module SetByListWithDuplicates =
    [<RequireQualifiedAccess>]
    type 'a Set = { Set: 'a list }

    let emptySet = { Set.Set = [] }

    let setEmpty { Set.Set = xs } =
        match xs with
        | [] -> true
        | _ -> false

    let inSet x { Set.Set = xs } =
        match xs with
        | [] -> false
        | _ -> List.contains x xs

    let addSet x ({ Set.Set = xs }) =
        { Set.Set = x :: xs }

    let delSet x ({ Set.Set = xs }) =
        { Set.Set = List.filter ((<>) x) xs }

// test
open SetByListWithDuplicates

emptySet |> printfn "%A"
emptySet |> setEmpty |> printfn "%A"
emptySet |> addSet 1 |> printfn "%A"

let set =
    emptySet
    |> addSet 1
    |> addSet 1
    |> addSet 2
    |> addSet 3

set |> delSet 10 |> printfn "%A"
set |> delSet 1 |> printfn "%A"
set |> delSet 2 |> printfn "%A"
set |> inSet 2 |> printfn "%A"
set |> inSet 10 |> printfn "%A"
