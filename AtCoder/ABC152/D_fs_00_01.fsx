#r "nuget: FsUnit"
open FsUnit

let N = 25
let N = 100
let N = 2020
let solve N =
  let charToInt: char -> int = string >> int
  let Ca = (Array2D.create 10 10 0, [|1..N|]) ||> Array.fold (fun acc n ->
    let s = string n
    let i = charToInt s.[0]
    let j = n%10
    Array2D.set acc i j (acc.[i,j]+1)
    acc)
  (0,[| for i in 1..9 do for j in 1..9 do (i,j) |]) ||> Array.fold (fun acc (i,j) -> acc + (Ca.[i,j] * Ca.[j,i]))

let N = stdin.ReadLine() |> int
solve N |> stdout.WriteLine

solve 25 |> should equal 17
solve 1 |> should equal 1
solve 100 |> should equal 108
solve 2020 |> should equal 40812
solve 200000 |> should equal 400000008
