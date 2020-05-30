(*
A priority queue is a queue in which each item has a priority associated with it.
Official implementation: https://github.com/fsprojects/FSharpx.Collections/blob/master/src/FSharpx.Collections/PriorityQueue.fs#L290
cf. https://stackoverflow.com/questions/3326512/f-priority-queue

The below list implementation is from Rabni-Lapalme, P.92.
Items are held in a sorted list.
*)

module PQueue =
    type 'a PQueue = { PQ: 'a list }
    let emptyPQ = { PQ = [] }

    let pqEmpty =
        function
        | { PQ = [] } -> true
        | _ -> false

    let rec insert x q =
        match x, q with
        | x, [] -> [ x ]
        | x, (e :: r' as r) -> if x <= e then x :: r else e :: insert x r'

    let enPQ x { PQ = q } = { PQ = insert x q }

    let dePQ { PQ = q } =
        match q with
        | [] -> failwith "dePQ: empty priority queue"
        | x :: xs -> { PQ = xs }

    let frontPQ { PQ = q } =
        match q with
        | [] -> failwith "frontPQ: empty priority queue"
        | x :: xs -> x

// test
open PQueue

emptyPQ |> printfn "%A"
emptyPQ |> pqEmpty |> printfn "%A"
emptyPQ |> enPQ 3 |> pqEmpty |> printfn "%A"
emptyPQ |> enPQ 3 |> enPQ 1 |> printfn "%A"

let pq = emptyPQ |> enPQ 3 |> enPQ 1 |> enPQ 2
pq |> dePQ |> printfn "%A"
pq |> frontPQ |> printfn "%A"
pq |> frontPQ |> printfn "%A"
