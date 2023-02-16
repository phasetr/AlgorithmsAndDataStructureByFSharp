#r "nuget: FsUnit"
open FsUnit

(*
let N = 20
*)
let solveTLE N =
  let isPrime x =
    if x=0||x=1 then false
    else let sq = (float >> sqrt >> int) x in [|2..sq|] |> Array.forall (fun n -> x%n<>0)
  [|2..N|] |> Array.filter isPrime

let solve N =
  let Ba = Array.create (N+1) false
  for i in 2..N do
    if not Ba.[i] then
      printfn "%A" i
      for j in 2..N/i do Ba.[i*j] <- true

let N = stdin.ReadLine() |> int
solve N

solve 20 // |> should equal [|2;3;5;7;11;13;17;19|]
