#r "nuget: FsUnit"
open FsUnit

type Dice = {one: int ; two: int ; three: int ; four: int ; five: int ; six: int }
type Direction = W | E | S | N | L | R

let solve (Aa:int[][]) =
  let roll dice =
    let {Dice.one = a; two = b; three = c; four = d; five = e; six = f} = dice
    function
      | W -> {dice with one = c; three = f; six = d; four = a}
      | E -> {dice with one = d; four = f; six = c; three = a}
      | S -> {dice with one = e; two = a; six = b; five = f}
      | N -> {dice with one = b; two = f; six = e; five = a}
      | L -> {dice with two = c; three = e; five = d; four = b}
      | R -> {dice with two = d; four = e; five = c; three = b}

  let makeAllDices dice =
    let directions1 = [[];[W];[E];[S];[N];[W; W]]
    let directions2 = [[];[L];[R];[L;L]]
    let f d lst = List.fold (fun e dir -> roll e dir) d lst
    List.map (f dice) directions1
    |> List.collect (fun x -> List.map (f x) directions2)

  let checkEq dice list = List.exists (fun x -> x = dice) list

  let rec checkSameDicesExist = function
    | [] -> false
    | x::xs ->
      let rec f a = function
        | [] -> false
        | y::ys -> checkEq x (makeAllDices y) || f x ys
      f x xs || checkSameDicesExist xs

  Aa |> Array.map (fun x -> {one=x.[0]; two=x.[1]; three=x.[2]; four=x.[3]; five=x.[4]; six=x.[5]})
  |> Array.toList
  |> fun x -> if checkSameDicesExist x then "No" else "Yes"

let N = stdin.ReadLine() |> int
let Aa = [| for i in 1..N do (stdin.ReadLine() |> Array.map |> int) |]
solve Aa |> stdout.WriteLine

let Aa = [|[|1;2;3;4;5;6|];[|6;2;4;3;5;1|];[|6;5;4;3;2;1|]|]
solve Aa |> should equal "No"
let Aa = [|[|1;2;3;4;5;6|];[|6;5;4;3;2;1|];[|5;4;3;2;1;6|]|]
solve Aa |> should equal "Yes"
