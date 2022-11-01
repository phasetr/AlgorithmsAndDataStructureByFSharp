#r "nuget: FsUnit"
open FsUnit

let N,M,Aa = 2,3,[|(1,32);(2,63);(1,12)|]
let solve N M Aa =
  let num i p = sprintf "%06i%06i" p (i+1)
  Aa |> Array.mapi (fun o (p,y) -> (o,p,y))
  |> Array.groupBy (fun (_,p,_) -> p)
  |> Array.collect (fun (_,e) -> e |> Array.sortBy (fun (_,_,y) -> y) |> Array.mapi (fun i (o,p,_) -> (o,num i p)))
  |> Array.sortBy fst |> Array.map snd

let N,M = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Aa = [| for i in 1..M do (stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0], x.[1])) |]
solve N M Aa |> String.concat "\n" |> stdout.WriteLine

solve 2 3 [|(1,32);(2,63);(1,12)|] |> should equal [|"000001000002";"000002000001";"000001000001"|]
solve 2 3 [|(2,55);(2,77);(2,99)|] |> should equal [|"000002000001";"000002000002";"000002000003"|]
