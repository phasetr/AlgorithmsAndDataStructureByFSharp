// From Rabhi-Lapalme
#r "nuget: FsUnit"
open FsUnit

type Queue<'a> = Queue of list<'a> * list<'a>

let queueEmpty: Queue<'a> -> bool = function
  | Queue([],[]) -> true
  | _ -> false

let emptyQueue: Queue<'a> = Queue ([],[])

let enqueue: 'a -> Queue<'a> -> Queue<'a>  = fun x -> function
  | Queue([],[]) -> Queue ([x],[])
  | Queue(xs,ys) -> Queue (xs, x::ys)

let dequeue: Queue<'a> -> Queue<'a> = function
  | Queue([],[]) -> failwith "dequeue: empty queue."
  | Queue([],ys) -> Queue(ys |> List.rev |> List.tail, [])
  | Queue(x::xs,ys) -> Queue(xs,ys)

let front: Queue<'a> -> 'a = function
  | Queue([],[]) -> failwith "front: empty queue."
  | Queue([], ys) -> List.last ys
  | Queue(x::xs,ys) -> x

emptyQueue |> queueEmpty |> should be True
emptyQueue |> enqueue 1 |> queueEmpty |> should be False
emptyQueue |> enqueue 1 |> should equal (Queue([1],[]))
emptyQueue |> enqueue 1 |> enqueue 2 |> should equal (Queue([1],[2]))
emptyQueue |> enqueue 1 |> enqueue 2 |> dequeue |> should equal (Queue([],[2]))
emptyQueue |> enqueue 1 |> enqueue 2 |> front |> should equal 1
