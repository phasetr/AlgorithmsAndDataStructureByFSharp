#r "nuget: FsUnit"
open FsUnit

(*
let N,Aa,Q,Ia = 7,[|0;1;1;0;1;0;0|],3,[|(2,5);(2,7);(5,7)|]
*)
let solve N Aa Q Ia =
  let Xa = (0,Aa) ||> Array.scan (+)
  Ia |> Array.map (fun (l,r) ->
    let w = Xa.[r] - Xa.[l-1]
    let l = r-l+1-w
    if l<w then "win" elif w=l then "draw" else "lose")

let N = stdin.ReadLine() |> int
let Aa = stdin.ReadLine().Split() |> Array.map int
let Q = stdin.ReadLine() |> int
let Ia = Array.init Q (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1])
solve N Aa Q Ia |> Array.iter stdout.WriteLine

solve 7 [|0;1;1;0;1;0;0|] 3 [|(2,5);(2,7);(5,7)|] |> should equal [|"win";"draw";"lose"|]
