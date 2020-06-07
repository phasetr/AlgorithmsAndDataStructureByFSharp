(*
https://atcoder.jp/contests/practice/tasks/practice_1
*)
let aTest = "1 2".Split(' ')

let fa =
    Array.map int
    >> Array.fold (*) 1
    >> (fun x -> if x % 2 = 0 then "Even" else "Odd")

aTest |> fa |> printfn "%s"

let main =
    stdin.ReadLine().Split(' ') |> fa |> printfn "%s"
