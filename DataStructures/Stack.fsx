#r "nuget: FsUnit"
open FsUnit

// https://en.wikibooks.org/wiki/F_Sharp_Programming/Advanced_Data_Structures
type 'a stack =
  | EmptyStack
  | StackNode of 'a * 'a stack

let hd = function
  | EmptyStack -> failwith "Empty stack"
  | StackNode(hd, tl) -> hd

let tl = function
  | EmptyStack -> failwith "Emtpy stack"
  | StackNode(hd, tl) -> tl

let cons hd tl = StackNode(hd, tl)

let emptyStack = EmptyStack

let rec update index value s =
  match index, s with
    | index, EmptyStack -> failwith "Index out of range"
    | 0, StackNode(hd, tl) -> StackNode(value, tl)
    | n, StackNode(hd, tl) -> StackNode(hd, update (index - 1) value tl)

let rec append x y =
  match x with
    | EmptyStack -> y
    | StackNode(hd, tl) -> StackNode(hd, append tl y)

let rec map f = function
  | EmptyStack -> EmptyStack
  | StackNode(hd, tl) -> StackNode(f hd, map f tl)

let rec rev s =
  let rec loop acc = function
    | EmptyStack -> acc
    | StackNode(hd, tl) -> loop (StackNode(hd, acc)) tl
  loop EmptyStack s

let rec contains x = function
  | EmptyStack -> false
  | StackNode(hd, tl) -> hd = x || contains x tl

let rec fold f seed = function
  | EmptyStack -> seed
  | StackNode(hd, tl) -> fold f (f seed hd) tl

// TEST
(*
|_1_|->|_2_|->|_3_|->|_4_|->|_5_|->Empty
*)
let stack = StackNode(1, StackNode(2, StackNode(3, StackNode(4, StackNode(5, EmptyStack)))))
hd stack |> should equal 1
tl stack |> should equal (StackNode (2, StackNode (3, StackNode (4, StackNode (5, EmptyStack)))))
