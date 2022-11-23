#r "nuget: FsUnit"
open FsUnit

let X,Y,A,B,C,Pa,Qa,Ra = 1,2,2,2,1,[|2L;4L|],[|5L;1L|],[|3L|]
let solve X Y A B C (Pa:int64[]) Qa Ra =
  let Ta = Array.append (Pa |> Array.sortDescending |> Array.take X) (Qa |> Array.sortDescending |> Array.take Y)
  Array.append Ta Ra |> Array.sortDescending |> Array.take (X+Y) |> Array.sum

let X,Y,A,B,C = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1],x.[2],x.[3],x.[4])
let Pa = stdin.ReadLine().Split() |> Array.map int64
let Qa = stdin.ReadLine().Split() |> Array.map int64
let Ra = stdin.ReadLine().Split() |> Array.map int64
solve X Y A B C Pa Qa Ra |> stdout.WriteLine

solve 1 2 2 2 1 [|2L;4L|] [|5L;1L|] [|3L|] |> should equal 12L
solve 2 2 2 2 2 [|8L;6L|] [|9L;1L|] [|2L;1L|] |> should equal 25L
solve 2 2 4 4 4 [|11L;12L;13L;14L|] [|21L;22L;23L;24L|] [|1L;2L;3L;4L|] |> should equal 74L
