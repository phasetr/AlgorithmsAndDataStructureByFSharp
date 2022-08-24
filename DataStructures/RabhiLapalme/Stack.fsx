// From Rabhi-Lapalme
#r "nuget: FsUnit"
open FsUnit

type 'a Stack = | EmptyStk | Stk of 'a * ('a Stack)

let emptyStack: 'a Stack = EmptyStk

let stackEmpty: 'a Stack -> bool = function
  | EmptyStk -> true
  | _ -> false

let push: 'a -> 'a Stack -> 'a Stack = fun x s -> Stk(x, s)

let pop: 'a Stack -> 'a Stack = function
  | EmptyStk -> failwith "pop from an empty stack."
  | Stk (_, s) -> s

let top: 'a Stack -> 'a = function
  | EmptyStk -> failwith "top from an empty stack."
  | Stk (x, _) -> x

let () =
  emptyStack |> stackEmpty |> should be True
  push 1 emptyStack |> stackEmpty |> should be False
  push 1 emptyStack |> top |> should equal 1
  push 1 emptyStack |> push 2 |> push 3 |> should equal (Stk(3, Stk(2, Stk(1, EmptyStk))))
  push 1 emptyStack |> push 2 |> push 3 |> pop |> should equal (Stk(2, Stk(1, EmptyStk)))
