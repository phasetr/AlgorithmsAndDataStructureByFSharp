// https://atcoder.jp/contests/abc156/tasks/abc156_c
#r "nuget: FsUnit"
open FsUnit

let solve Xa =
    let calc party = Array.sumBy (fun x -> pown (x - party) 2)
    let min = Array.min Xa
    let max = Array.max Xa
    [ for x in [min..max] do yield calc x Xa ] |> List.min

stdin.ReadLine() |> ignore
stdin.ReadLine().Split(' ') |> Array.map int |> solve |> stdout.WriteLine

solve [|1;4|] |> should equal 5
solve [|14;14;2;13;56;2;37;|] |> should equal 2354
