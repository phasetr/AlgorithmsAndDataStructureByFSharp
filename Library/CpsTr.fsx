#r "nuget: FsUnit"
open FsUnit

"See https://bleis-tift.hatenablog.com/entry/cps"
module FactSample =
    let rec fact0 = function
        | n when n = 0I -> 1I
        | n -> n * (fact (n - 1I))

    let rec fact1 n cont =
        if n = 0I then 1I |> cont
        else
            fact1 (n - 1I) (fun pre -> n * pre |> cont)
    fact1 100I id

    let fact2 n =
        let rec frec n cont =
            if n = 0I then 1I |> cont
            else
                frec (n - 1I) (fun pre ->  n * pre |> cont)
        frec n id
    fact2 5000I

module SumSample =
    "オリジナル"
    let rec sum = function
    | [] -> 0
    | x::xs -> x + (sum xs)
    "letで書き換え"
    let rec sum xs =
        match xs with
            | [] -> 0
            | x::xs ->
                let pre = sum xs
                x + pre
    "CPS!"
    let sum xs =
        let rec frec xs cont =
            match xs with
                | [] -> 0 |> cont
                | x::xs -> frec xs (fun pre -> x + pre |> cont)
        frec xs id
