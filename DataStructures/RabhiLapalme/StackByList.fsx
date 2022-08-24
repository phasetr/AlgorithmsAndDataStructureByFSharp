#r "nuget: FsUnit"
open FsUnit

type Stack<'a> = Stk of list<'a>

let emptyStack: Stack<'a> = Stk []

let stackEmpty: Stack<'a> -> bool = function
  | Stk [] -> true
  | _ -> false

let push: 'a -> Stack<'a> -> Stack<'a> = fun x (Stk xs) -> Stk (x::xs)

let pop: Stack<'a> -> Stack<'a> = function
  | Stk [] -> failwith "pop from an empty stack"
  | Stk (_::xs) -> Stk xs

let top: Stack<'a> -> 'a = function
  | Stk [] -> failwith "top from an empty stack"
  | Stk (x::_) -> x

let () =
  emptyStack |> stackEmpty |> should be True
  push 1 emptyStack |> stackEmpty |> should be False
  push 1 emptyStack |> top |> should equal 1
  push 1 emptyStack |> push 2 |> push 3 |> should equal (Stk [3;2;1])
  push 1 emptyStack |> push 2 |> push 3 |> pop |> should equal (Stk [2;1])
