#r "nuget: FsUnit"
open FsUnit

let solve a b cDeg =
  let cRad = cDeg * System.Math.PI / 180.0
  let h = b*(sin cRad)
  let c = sqrt ((a-b*(cos cRad))**2.0 + h**2.0)
  [|a*h/2.0; a+b+c; h|]

let a,b,C = stdin.ReadLine().Split() |> Array.map float |> (fun x -> x.[0],x.[1],x.[2])
solve Xa |> Array.map string |> String.concat "\n" |> stdout.WriteLine

let near0 x y = (abs (x-y)) < 0.000_1
Array.map2 (fun x y -> near0 x y) (solve 4 3 90) [|6.000;12.000;3.000|] |> Array.forall id |> should be True
