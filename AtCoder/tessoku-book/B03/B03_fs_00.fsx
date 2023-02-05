#r "nuget: FsUnit"
open FsUnit

(*
let N,Aa = 5,[|100;250;350;400;600|]
let N,Aa = 10,[|50;150;250;350;450;550;650;750;850;950|]
*)
let solve N (Aa:int[]) =
  [| for i in 0..N-3 do for j in (i+1)..N-2 do for k in (j+1)..N-1 do if Aa.[i]+Aa.[j]+Aa.[k]=1000 then yield true |]
  |> fun x -> if x.Length=0 then "No" else "Yes"
let N = stdin.ReadLine() |> int
let Aa = stdin.ReadLine().Split() |> Array.map int
solve N Aa |> stdout.WriteLine

solve 5 [|100;250;350;400;600|] |> should equal "Yes"
solve 10 [|50;150;250;350;450;550;650;750;850;950|] |> should equal "No"
