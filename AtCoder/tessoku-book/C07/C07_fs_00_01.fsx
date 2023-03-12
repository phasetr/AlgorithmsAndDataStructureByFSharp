#r "nuget: FsUnit"
open FsUnit

(*
let N,Ca,Q,Xa = 5,[|300;100;400;100;500|],3,[|500;250;40|]
let N,Ca,Q,Xa = 10,[|100;100;100;100;100;100;100;100;100;100|],11,[|90;190;290;390;490;590;690;790;890;990;100000000|]
*)
let solve N Ca Q Xa =
  let Sa = (0, Array.sort Ca) ||> Array.scan (fun acc c -> acc+c)
  let bsearch x =
    let mutable l,r = 0,N+1
    while r-l>1 do let m = (l+r)/2 in if Sa.[m]<=x then l<-m else r<-m
    l
  Xa |> Array.map (fun x -> bsearch x)

let N = stdin.ReadLine() |> int
let Ca = stdin.ReadLine().Split() |> Array.map int
let Q = stdin.ReadLine() |> int
let Xa = Array.init Q (fun _ -> stdin.ReadLine() |> int)
solve N Ca Q Xa |> Array.iter stdout.WriteLine

solve 5 [|300;100;400;100;500|] 3 [|500;250;40|] |> should equal [|3;2;0|]
solve 10 [|100;100;100;100;100;100;100;100;100;100|] 11 [|90;190;290;390;490;590;690;790;890;990;100000000|] |> should equal [|0..10|]
