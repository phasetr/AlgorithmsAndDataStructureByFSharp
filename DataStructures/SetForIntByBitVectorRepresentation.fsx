// Rabhi-Lapalme P.95
open System

System.Int32.MaxValue
|> double
|> Math.Log2
|> Math.Round
|> int

module SetForIntByBitVectorRepresentation =
    [<RequireQualifiedAccess>]
    type IntSet = { Int: int }

    let maxSet =
        System.Int32.MaxValue
        |> double
        |> Math.Log2
        |> Math.Round
        |> int

    let isLegal i = i >= 0 && i <= maxSet

    let emptySet = { IntSet.Int = 0 }
    let setEmpty { IntSet.Int = i } = i = 0

    let inSet i { IntSet.Int = s } =
        if isLegal i
        then (s / (pown 2 i) % 2 = 1)
        else failwith (String.Format("inSet: illegal element = {0}", i))

    let addSet i { IntSet.Int = s } =
        if isLegal i then
            let e = pown 2 i
            let d = s / e
            let m = s % e
            let d1 = if d % 2 = 1 then d else d + 1
            { IntSet.Int = d1 * e + m }
        else
            failwith (String.Format("addSet: illegal element = {0}", i))

    let delSet i { IntSet.Int = s } =
        if isLegal i then
            let e = pown 2 i
            let d = s / e
            let m = s % e
            let d1 = if d % 2 = 1 then d - 1 else d
            { IntSet.Int = d1 * e + m }
        else
            failwith (String.Format("delSet: illegal element = {0}", i))

    let toList { IntSet.Int = s } =
        let rec s2l t n =
            match t, n with
            | 0, _ -> []
            | n, i -> if n % 2 = 1 then i :: s2l (n / 2) (i + 1) else s2l (n / 2) (i + 1)

        s2l s 0

// Test
open SetForIntByBitVectorRepresentation

emptySet |> printfn "%A"
emptySet |> setEmpty |> printfn "%A"
emptySet |> addSet 1 |> printfn "%A"

let set =
    emptySet
    |> addSet 1
    |> addSet 1
    |> addSet 2
    |> addSet 3

set |> toList |> printfn "%A"
set |> delSet 10 |> printfn "%A"
set |> delSet 1 |> printfn "%A"
set |> delSet 2 |> printfn "%A"
set |> inSet 1 |> printfn "%A"
set |> inSet 2 |> printfn "%A"
set |> inSet 10 |> printfn "%A"
