// https://atcoder.jp/contests/abc094/submissions/28265033
let _ = stdin.ReadLine()

let a =
    stdin.ReadLine().Split()
    |> Array.map int
    |> Array.sortDescending

let x = Array.get a 0

let y =
    a
    |> Array.tail
    |> Array.minBy (fun k -> abs (2 * k - x))

printfn "%i %i" x y
