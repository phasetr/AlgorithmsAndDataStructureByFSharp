(*
Rabhi-Lapalme P94
*)

module SetByUnorderedListWithoutDuplicates =
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

    /// Different from SetByListWithDuplicates
    let addSet x ({ Set.Set = xs } as s) =
        if inSet x s then s else { Set.Set = x :: xs }

    /// Different from SetByListWithDuplicates
    let delSet x ({ Set.Set = xs }) = { Set.Set = List.filter ((<>) x) xs }

    /// From Haskell http://hackage.haskell.org/package/base-4.14.0.0/docs/src/Data.OldList.html#delete
    let rec deleteBy f x xs =
        match xs with
        | y :: ys -> if f x y then ys else y :: deleteBy f x ys
        | _ -> []

    /// From Haskell http://hackage.haskell.org/package/base-4.14.0.0/docs/src/Data.OldList.html#delete
    let rec delete (x: 'a when 'a: equality) xs = deleteBy (=) x xs


// test
open SetByUnorderedListWithoutDuplicates

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
