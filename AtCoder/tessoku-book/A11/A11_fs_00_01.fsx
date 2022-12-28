#r "nuget: FsUnit"
open FsUnit

(*
let N,X,Ia = 15,47,[|11;13;17;19;23;29;31;37;41;43;47;53;59;61;67|]
let N,X,Ia = 10,80,[|10;20;30;40;50;60;70;80;90;100|]
*)
let solve N X (Ia:int[]) =
  let rec binSrch l r =
    let m = (l+r)/2
    if r<l then None
    elif Ia.[m]=X then Some m
    elif X<Ia.[m] then binSrch l (m-1)
    else binSrch (m+1) r
  binSrch 0 (N-1) |> Option.map ((+) 1) |> Option.defaultValue (-1)

let N,X = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Ia = stdin.ReadLine().Split() |> Array.map int
solve N X Ia |> stdout.WriteLine

solve 15 47 [|11;13;17;19;23;29;31;37;41;43;47;53;59;61;67|] |> should equal 11
solve 10 80 [|10;20;30;40;50;60;70;80;90;100|] |> should equal 8
