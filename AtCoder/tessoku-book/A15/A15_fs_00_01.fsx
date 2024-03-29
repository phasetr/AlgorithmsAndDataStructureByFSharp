#r "nuget: FsUnit"
open FsUnit

(*
let N,Aa = 5,[|46;80;11;77;46|]
*)
let solve N Aa =
  let Xa = Aa |> Array.distinct |> Array.sort
  let rec bsearch x (Ia:int[]) =
    let mutable l,r = -1,Ia.Length
    while r-l>1 do let m = (l+r)/2 in if x<=Ia.[m] then r<-m else l<-m
    r
  Aa |> Array.map (fun a -> bsearch a Xa + 1)

let N = stdin.ReadLine() |> int
let Aa = stdin.ReadLine().Trim().Split() |> Array.map int
solve N Aa |> Array.map string |> String.concat " " |> stdout.WriteLine

solve 5 [|46;80;11;77;46|] |> should equal [|2;4;1;3;2|]
