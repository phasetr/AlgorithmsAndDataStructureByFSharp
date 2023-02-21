#r "nuget: FsUnit"
open FsUnit

(*
let N,D,Ia = 5,4,[|(1,1);(2,4);(2,3);(3,4);(4,2)|]
*)
let solveTLE N D (Ia:(int*int)[]) =
  let Ja = Ia |> Array.indexed
  ((0,Array.create N false), [|1..D|])
  ||> Array.fold (fun (acc,used) i ->
    ((0,-1), Ja) ||> Array.fold (fun (mV,mId) (j,(x,y)) ->
      if (not used.[j]) && mV < y && x <= i then (y,j) else (mV,mId))
    |> fun (mV,mId) ->
      if mId<>(-1) then used.[mId] <- true
      (acc + if mId=(-1) then 0 else mV), used)
  |> fst

let solve N D (Ia:(int*int)[]) =
  let mutable answer = 0
  let used = Array.create N false
  let rec frec i j mV mId =
    if j=N then (mV,mId)
    elif used.[j] then frec i (j+1) mV mId
    else let x,y = Ia.[j] in if mV < y && x <= i then frec i (j+1) y j else frec i (j+1) mV mId
  for i in 1..D do
    frec i 0 0 (-1)
    |> fun (mV,mId) -> if mId <> (-1) then answer <- answer+mV; used.[mId] <- true
  answer

let N,D = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Ia = Array.init N (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1])
solve N D Ia |> stdout.WriteLine

solve 5 4 [|(1,1);(2,4);(2,3);(3,4);(4,2)|] |> should equal 12
