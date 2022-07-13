#r "nuget: FsUnit"
open FsUnit

// https://en.wikibooks.org/wiki/F_Sharp_Programming/Advanced_Data_Structures#Queue_From_Two_Stacks
#load "Stack.fsx"
open Stack

type 'a Queue = Queue of 'a stack * 'a stack

let emptyQueue = Queue(emptyStack,emptyStack)

let check = function
  | Queue(EmptyStack, r) -> Queue(rev r, EmptyStack)
  | Queue(f,r) -> Queue(f,r)

let hd = function
  | Queue(EmptyStack,_) -> failwith "empty"
  | Queue(StackNode(hd,_),_) -> hd

let tl = function
  | Queue(EmptyStack,_) -> failwith "empty"
  | Queue(StackNode(x,f),r) -> check (Queue(f,r))

let enqueue x = function
  | Queue(f,r) -> check (Queue(f,(StackNode(x,r))))

let toString q = sprintf "%A" q

let q1 = enqueue 1 emptyQueue
q1 |> should equal (Queue (StackNode (1, EmptyStack), EmptyStack))
let q2 = enqueue 2 q1
q2 |> should equal (Queue (StackNode (1, EmptyStack), StackNode (2, EmptyStack)))
let q3 = enqueue 3 q2
q3 |> should equal (Queue (StackNode (1, EmptyStack), StackNode (2, EmptyStack))Queue (StackNode (1, EmptyStack), StackNode (3, StackNode (2, EmptyStack))))

hd q3 |> should equal 1
tl q3 |> should equal (Queue (StackNode (2, StackNode (3, EmptyStack)), EmptyStack))
