// From Rabhi-Lapalme
#r "nuget: FsUnit"
open FsUnit

type 'a Queue = Q of 'a list * 'a list

let queueEmpty: 'a Queue -> bool = function
  | Q([],[]) -> true
  | _ -> false

let emptyQueue: 'a Queue = Q ([],[])

let enqueue: 'a -> 'a Queue -> 'a Queue  = fun x -> function
  | Q([],[]) -> Q ([x],[])
  | Q(xs,ys) -> Q (xs, x::ys)

let dequeue: 'a Queue -> 'a Queue = function
  | Q([],[]) -> failwith "dequeue: empty queue."
  | Q([],ys) -> Q(ys |> List.rev |> List.tail, [])
  | Q(x::xs,ys) -> Q(xs,ys)

let front: 'a Queue -> 'a = function
  | Q([],[]) -> failwith "front: empty queue."
  | Q([], ys) -> List.last ys
  | Q(x::xs,ys) -> x

emptyQueue |> queueEmpty |> should be True
emptyQueue |> enqueue 1 |> queueEmpty |> should be False
emptyQueue |> enqueue 1 |> should equal (Q([1],[]))
emptyQueue |> enqueue 1 |> enqueue 2 |> should equal (Q([1],[2]))
emptyQueue |> enqueue 1 |> enqueue 2 |> dequeue |> should equal (Q([],[2]))
emptyQueue |> enqueue 1 |> enqueue 2 |> front |> should equal 1
