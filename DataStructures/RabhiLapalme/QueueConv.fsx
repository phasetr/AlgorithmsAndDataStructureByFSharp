// From Rabhi-Lapalme, converted
#r "nuget: FsUnit"
open FsUnit

type Queue<'a> = { Front: list<'a>; Rear: list<'a> }

let queueEmpty: Queue<'a> -> bool = function
  | { Front = []; Rear = [] } -> true
  | _ -> false

let emptyQueue: Queue<'a> = { Front = []; Rear = [] }

let enqueue: 'a -> Queue<'a> -> Queue<'a>  = fun x -> function
  | { Front = []; Rear = [] } -> { Front = [ x ]; Rear = [] }
  | { Front = f; Rear = r } -> { Front = f; Rear = x :: r }

let dequeue: Queue<'a> -> Queue<'a> = function
  | { Front = []; Rear = [] } -> failwith "dequeue: empty queue."
  | { Front = []; Rear = r } -> { Front = r |> List.rev |> List.tail; Rear = [] }
  | { Front = f :: fs; Rear = r } -> { Front = fs; Rear = r }

let front: Queue<'a> -> 'a = function
  | { Front = []; Rear = [] } -> failwith "front: empty queue."
  | { Front = []; Rear = r } -> List.last r
  | { Front = f :: _; Rear = _ } -> f

emptyQueue |> queueEmpty |> should be True
emptyQueue |> enqueue 1 |> queueEmpty |> should be False
emptyQueue |> enqueue 1 |> should equal { Front = [1]; Rear = [] }
emptyQueue |> enqueue 1 |> enqueue 2 |> should equal { Front = [1]; Rear = [2] }
emptyQueue |> enqueue 1 |> enqueue 2 |> dequeue |> should equal { Front = []; Rear = [2] }
emptyQueue |> enqueue 1 |> enqueue 2 |> front |> should equal 1
