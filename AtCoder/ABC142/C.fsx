// https://atcoder.jp/contests/abc142/tasks/abc142_c
let judge: int array -> string =
    Array.mapi (fun i x -> (x, i + 1))
    >> Array.sortBy (fun x -> x |> fst)
    >> Array.map (snd >> string)
    >> String.concat " "
//let input = [| 3, [|2;3;1|]; 5, [|1;2;3;4;5|]; 8, [|8;2;7;3;4;5;6;1|] |]
//for _, a in input do (judge a |> printfn "%s")
// expected 3 1 2; 1 2 3 4 5; 8 2 4 5 6 7 3 1
[<EntryPoint>]
let main argv =
    stdin.ReadLine() |> ignore
    stdin.ReadLine().Split()
    |> Array.map int
    |> judge
    |> printfn "%s"
    0
