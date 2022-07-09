#r "nuget: FsUnit"
open FsUnit

let solve w h x y r =
    match (0<x,0<y) with
        | (true,true) -> if (0<=x-r && r+x<=w && 0<=y-r && r+y<=h) then "Yes" else "No"
        | _ -> "No"
let w,h,x,y,r = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1],x.[2],x.[3],x.[4])
solve w h x y r |> stdout.WriteLine

solve 5 4 2 2 1 |> should equal "Yes"
solve 5 4 2 4 1 |> should equal "No"
