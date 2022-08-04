#r "nuget: FsUnit"
open FsUnit

type Dice = {one: int; two: int; three: int; four: int; five: int; six: int }
type Dir = W | E | S | N | L | R

let Xa = [|1..6|]
let Ya = [|6;2;4;3;5;1|]
let solve Xa Ya =
  let dir1 = [|[||];[|W|];[|E|];[|S|];[|N|];[|W; W|]|]
  let dir2 = [|[||];[|L|];[|R|];[|L;L|]|]
  let roll (dice: Dice) =
    let {Dice.one = a; two = b; three = c; four = d; five = e; six = f} = dice
    function
      | W -> {dice with one = c; three = f; six = d; four = a}
      | E -> {dice with one = d; four = f; six = c; three = a}
      | S -> {dice with one = e; two = a; six = b; five = f}
      | N -> {dice with one = b; two = f; six = e; five = a}
      | L -> {dice with two = c; three = e; five = d; four = b}
      | R -> {dice with two = d; four = e; five = c; three = b}
  let makeAllDices dice =
    let f d xa = Array.fold (fun e dir -> roll e dir) d xa
    dir1 |> Array.map (f dice) |> Array.map (fun x -> Array.map (f x) dir2) |> Array.concat

  let toDice (x: int[]) = {one=x.[0]; two=x.[1]; three=x.[2]; four=x.[3]; five=x.[4]; six=x.[5]}
  let d1 = toDice Xa
  let d2 = toDice Ya
  let da = makeAllDices d2
  if Array.exists (fun x -> x = d1) da then "Yes" else "No"

let Xa = stdin.ReadLine().Split() |> Array.map int
let Ya = stdin.ReadLine().Split() |> Array.map int
solve Xa Ya |> stdout.WriteLine

solve [|1..6|] [|6;2;4;3;5;1|] |> should equal "Yes"
solve [|1..6|] [|6;5;4;3;2;1|] |> should equal "No"
