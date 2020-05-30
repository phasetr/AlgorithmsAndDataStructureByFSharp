// From Rabhi-Lapalme
module Queue =
    type 'a Queue = { Front: 'a List; Rear: 'a List }

    let queueEmpty =
        function
        | { Front = []; Rear = [] } -> true
        | _ -> false

    let emptyQueue = { Front = []; Rear = [] }

    let enqueue x q =
        match q with
        | { Front = []; Rear = [] } -> { Front = [ x ]; Rear = [] }
        | { Front = f; Rear = r } -> { Front = f; Rear = x :: r }

    let dequeue =
        function
        | { Front = []; Rear = [] } -> failwith "dequeue: empty queue."
        | { Front = []; Rear = r } ->
            { Front = r |> List.rev |> List.tail
              Rear = [] }
        | { Front = f :: fs; Rear = r } -> { Front = fs; Rear = r }

    let front =
        function
        | { Front = []; Rear = [] } -> failwith "front: empty queue."
        | { Front = []; Rear = r } -> List.last r
        | { Front = f :: _; Rear = _ } -> f

// test
open Queue

emptyQueue |> queueEmpty |> printfn "%A" // true
emptyQueue |> enqueue 1 |> queueEmpty |> printfn "%A" // false
emptyQueue |> enqueue 1 |> printfn "%A" // { Front = [1]; Rear = []}
emptyQueue |> enqueue 1 |> enqueue 2 |> printfn "%A" // { Front = [1]; Rear = [2] }
emptyQueue |> enqueue 1 |> enqueue 2 |> dequeue |> printfn "%A" // { Front = []; Rear = [2] }
emptyQueue |> enqueue 1 |> enqueue 2 |> front |> printfn "%A" // 1