module Stack =
    type 'a Stack =
        | EmptyStk
        | Stk of 'a * 'a Stack

    let push x s = Stk(x, s)

    let pop =
        function
        | EmptyStk -> failwith "pop from an empty stack."
        | Stk (_, s) -> s

    let top =
        function
        | EmptyStk -> failwith "top from an empty stack."
        | Stk (x, _) -> x

    let emptyStack = EmptyStk

    let stackEmpty =
        function
        | EmptyStk -> true
        | _ -> false
// From Rabhi-Lapalme

// test
open Stack

emptyStack |> printfn "%A" // EmptyStk
emptyStack |> stackEmpty |> printfn "%b" // true
push 1 emptyStack |> stackEmpty |> printfn "%b" // false
push 1 emptyStack |> top |> printfn "%A" // 1

push 1 emptyStack
|> push 2
|> push 3
|> printfn "%A" // Stk (3,Stk (2,Stk (1,EmptyStk)))

push 1 emptyStack
|> push 2
|> push 3
|> pop
|> printfn "%A" //
