#r "nuget: FsUnit"
open FsUnit

(*
let N,M,Aa = 3,4,[|[|0;0;1|];[|0;1;0|];[|1;0;0|];[|1;1;0|]|]
let N,M,Aa = 10,2,[|[|1;1;1;1;0;0;0;0;0;0|];[|0;0;0;0;1;1;1;1;0;0|]|]
nn*)
let solve N M Aa =
  let toBin a = ((0,0), a) ||> Array.fold (fun (i,acc) a -> (i+1, acc + if a=0 then 0 else pown 2 i)) |> snd
  Array.create (1<<<N) (M+1)
  |> fun dp -> dp.[0] <- 0; dp
  |> fun dp -> (dp, [|0..M-1|]) ||> Array.fold (fun dp i ->
    [|0..(1<<<N)-1|] |> Array.iter (fun bit ->
      let v = Array.get Aa i |> toBin
      dp.[bit ||| v] <- min dp.[bit ||| v] (dp.[bit]+1)
    )
    dp)
  |> fun dp -> let v = Array.last dp in if M<v then -1 else v

let N,M = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Aa = Array.init M (fun _ -> stdin.ReadLine().Split() |> Array.map int)
solve N M Aa |> stdout.WriteLine

solve 3 4 [|[|0;0;1|];[|0;1;0|];[|1;0;0|];[|1;1;0|]|] |> should equal 2
solve 10 2 [|[|1;1;1;1;0;0;0;0;0;0|];[|0;0;0;0;1;1;1;1;0;0|]|] |> should equal (-1)
