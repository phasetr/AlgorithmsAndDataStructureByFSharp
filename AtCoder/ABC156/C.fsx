// https://atcoder.jp/contests/abc156/tasks/abc156_c
let calc party = Array.sumBy (fun x -> pown (x - party) 2)
let fc coords =
    let min = Array.min coords
    let max = Array.max coords
    [ for x in [min..max] do yield calc x coords ] |> List.min

//let input = [| [| 1; 4|]; [| 14; 14; 2; 13; 56; 2; 37; |] |]
//for i in input do fc i |> printfn "%d"
// expected 5; 2354

[<EntryPoint>]
let main argv =
    stdin.ReadLine() |> ignore
    stdin.ReadLine().Split(' ') |> Array.map int |> fc |> printfn "%d"
    0
