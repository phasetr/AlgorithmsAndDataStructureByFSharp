#r "nuget: FsUnit"
open FsUnit

(*
let N,M,Ia = 7,9,[|(1,2,12);(1,3,10);(2,6,160);(2,7,15);(3,4,1);(3,5,4);(4,5,3);(4,6,120);(6,7,14)|]
*)
let solve N M Ia =
  let edge = Ia |> Array.map (fun (a,b,c) -> (a-1,b-1,c)) |> Array.sortBy (fun (_,_,c) -> -c)
  let uf = Array.create N (-1)
  let root i =
    let rec frec i = if uf.[i]<0 then i elif uf.[uf.[i]]<0 then uf.[i] else uf.[i] <- uf.[uf.[i]]; frec i
    frec i
  let unite i0 j0 =
    let mutable i,j = root i0,root j0
    if i=j then false
    else
      if uf.[j] > uf.[j] then i<-j; j<-i
      uf.[i] <- uf.[i]+uf.[j]
      uf.[j] <- i
      true
  (0,edge) ||> Array.fold (fun acc (a,b,c) -> if unite a b then acc+c else acc)

let N,M = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Ia = Array.init M (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1],x.[2])
solve N M Ia |> stdout.WriteLine

solve 7 9 [|(1,2,12);(1,3,10);(2,6,160);(2,7,15);(3,4,1);(3,5,4);(4,5,3);(4,6,120);(6,7,14)|] |> should equal 321
