/// https://atcoder.jp/contests/abc083/tasks/abc083_b
// sol 1
let bTest =
    "20 2 5".Split(' ')
    |> Array.map int
    |> List.ofArray

let fb =
    function
    | [] -> 0
    | x :: xs ->
        let ns = [| 1 .. x |]
        ns
        |> Array.map (string >> Seq.sumBy (fun x -> int x - int '0'))
        |> Array.mapi (fun i x -> if (xs.[0] <= x && x <= xs.[1]) then ns.[i] else 0)
        |> Array.sum

bTest |> fb |> printfn "%d"

let main =
    stdin.ReadLine().Split(' ')
    |> Array.map int
    |> List.ofArray
    |> fb
    |> printfn "%d"
