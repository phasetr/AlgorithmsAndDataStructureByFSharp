#r "nuget: FsUnit"
open FsUnit

let solve (aa:int[]) =
  ((1000000,-1000000,0), aa)
  ||> Array.fold (fun (minV, maxV, sumV) ai -> (min minV ai, max maxV ai, sumV + ai))

let n = stdin.ReadLine() |> int
let aa = stdin.ReadLine().Split() |> Array.map int
solve aa |> (fun (a,b,c) -> "%d %d %d" a b c |> printfn)

solve [|10;1;5;4;17|] |> should equal (1,17,37)
