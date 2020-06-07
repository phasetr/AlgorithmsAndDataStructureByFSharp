(*
Rabhi-Lapalme P.94
Testing for membership can be done faster.
If the element is not in the list,
the test for membership and the deletion opration can be terminated
earlier than in the second implementation.
In the worst case, these operations take a linear number of steps.
*)

module SetByOrderedListWithoutDuplicates =
    [<RequireQualifiedAccess>]
    type 'a Set = { Set: 'a list }

    let emptySet = { Set.Set = [] }

    let setEmpty { Set.Set = xs } =
        match xs with
        | [] -> true
        | _ -> false

    /// Different from SetBYUnorderdListWithoutDuplicates
    let inSet x { Set.Set = xs } =
        List.takeWhile (fun y -> y <= x) xs
        |> List.contains x

    /// Different from SetByListWithDuplicates
    let addSet x ({ Set.Set = xs } as s) =
        let rec add x xs =
            match xs with
            | [] -> [ x ]
            | y :: ys as s ->
                if x < y then x :: s
                elif x = y then s
                else y :: (add x ys)

        { Set.Set = add x xs }

    /// Different from SetByListWithDuplicates
    let delSet x ({ Set.Set = xs }) =
        let rec del x xs =
            match xs with
            | [] -> []
            | y :: ys as s ->
                if x < y then s
                elif x = y then ys
                else y :: (del x ys)

        { Set.Set = del x xs }



// test
open SetByOrderedListWithoutDuplicates

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
