#r "nuget: FsUnit"
open FsUnit

let solve r = let pi = System.Math.PI in let r0 = float r in (pi*r0*r0, 2.0*pi*r0)

let r = stdin.ReadLine() |> int
solve r |> (fun (x,y) -> printfn "%4.f %4.f" x y)

let near0 x y = (abs (x-y)) < 0.000_01
solve 2 |> (fun (x,y) -> near0 x 12.566371 && near0 y 12.566371) |> should be True
solve 3 |> (fun (x,y) -> near0 x 28.274334 && near0 y 18.849556) |> should be True
