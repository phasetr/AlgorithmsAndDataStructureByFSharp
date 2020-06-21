// https://atcoder.jp/contests/abc169/tasks/abc169_a
let aTest = [| [| "2"; "5" |]; [| "100"; "100" |] |]
let aAns = [| 10; 10000 |]

let fa: string [] -> int = Array.map int >> Array.fold (*) 1

Array.map2 (=) (aTest |> Array.map fa) aAns

let main =
    stdin.ReadLine().Split(' ') |> fa |> printfn "%d"
