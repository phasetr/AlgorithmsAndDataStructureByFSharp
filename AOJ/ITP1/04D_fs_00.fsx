#r "nuget: FsUnit"
open FsUnit

let solve (aa:int[]) = (Array.min aa, Array.max aa, Array.sum aa)

let n = stdin.ReadLine() |> int
let aa = stdin.ReadLine().Split() |> Array.map int
solve aa |> (fun (a,b,c) -> "%d %d %d" a b c |> printfn)

solve [|10;1;5;4;17|] |> should equal (1,17,37)
