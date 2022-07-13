#r "nuget: FsUnit"
open FsUnit

// 要素の型が全て一致しなければならないから配列は返せない
let solve (a:int) (b:int) = (a/b, a%b, (float a) / (float b))

let a,b = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])
solve a b |> (fun (x,y,z) -> printfn "%d %d %.4f" x y z)

let near0 x y = (abs (x-y)) < 0.000_01
solve 3 2 |> (fun (x,y,z) -> x=1 && y=1 && near0 z 1.5000) |> should be True
