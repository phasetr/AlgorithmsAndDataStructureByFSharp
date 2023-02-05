#r "nuget: FsUnit"
open FsUnit

(*
let N,Pa = 4,[|[|0;0;2;0|];[|3;0;0;0|];[|0;0;0;4|];[|0;1;0;0|]|]
*)
let solve N Pa =
  let Xa,Ya =
    let Xa = Array.create N 0
    let Ya = Array.create N 0
    Pa |> array2D |> Array2D.iteri (fun i j v -> if v<>0 then Xa.[i] <- v; Ya.[j] <- v)
    Xa,Ya
  let mutable x,y = 0,0
  for i in 0..N-1 do
    for j in (i+1)..N-1 do
      if Xa.[j]<Xa.[i] then x<-x+1
      if Ya.[j]<Ya.[i] then y<-y+1
  x+y

let N = stdin.ReadLine() |> int
let Pa = Array.init N (fun _ -> stdin.ReadLine().Split() |> Array.map int)
solve N Pa |> stdout.WriteLine

solve 4 [|[|0;0;2;0|];[|3;0;0;0|];[|0;0;0;4|];[|0;1;0;0|]|] |> should equal 5
