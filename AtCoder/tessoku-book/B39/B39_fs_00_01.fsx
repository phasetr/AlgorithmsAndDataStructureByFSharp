#r "nuget: FsUnit"
open FsUnit

(*
let N,D,Ia = 5,4,[|(1,1);(2,4);(2,3);(3,4);(4,2)|]
*)
let solve N D (Ia:(int*int)[]) =
  let mutable answer = 0
  let used = Array.create N false
  for i in 1..D do
    let mutable maxValue,maxId = 0,-1
    for j in 0..N-1 do
      let x,y = Ia.[j]
      if (not used.[j]) && maxValue < y && x <= i then maxValue <- y; maxId <- j
    if maxId <> (-1) then answer <- answer+maxValue; used.[maxId] <- true
  answer

let N,D = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Ia = Array.init N (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1])
solve N D Ia |> stdout.WriteLine

solve 5 4 [|(1,1);(2,4);(2,3);(3,4);(4,2)|] |> should equal 12
