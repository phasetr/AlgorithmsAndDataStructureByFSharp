#r "nuget: FsUnit"
open FsUnit

(*
let X,Y = 5,2
let X,Y = 1,1
*)
let solve X Y =
  let rec frec acc x y =
    if x<2 && y<2 then acc
    else let x0,y0 = if x<y then (x,y-x) else (x-y,y) in frec ((x,y)::acc) x0 y0
  frec [] X Y |> fun As -> (string As.Length) :: (As |> List.map (fun (x,y) -> sprintf "%d %d" x y))

let X,Y = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
solve X Y |> List.iter stdout.WriteLine

solve 5 2 |> should equal ["3";"1 2";"3 2";"5 2"]
solve 1 1 |> should equal ["0"]
