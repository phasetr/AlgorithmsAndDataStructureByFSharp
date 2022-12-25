#r "nuget: FsUnit"
open FsUnit

(*
let N,K,Pa,Qa = 3,100,[|17;57;99|],[|10;36;53|]
let N,K,Pa,Qa = 5,53,[|10;20;30;40;50|],[|1;2;3;4;5|]
*)
let solve N K Pa Qa =
  Pa
  |> Array.collect (fun p -> Qa |> Array.choose (fun q -> let s=p+q in if s=K then Some s else None))
  |> fun Xa -> if Array.isEmpty Xa then "No" else "Yes"

let N,K = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Pa = stdin.ReadLine().Split() |> Array.map int
let Qa = stdin.ReadLine().Split() |> Array.map int
solve N K Pa Qa |> stdout.WriteLine

solve 3 100 [|17;57;99|] [|10;36;53|] |> should equal "No"
solve 5 53 [|10;20;30;40;50|] [|1;2;3;4;5|] |> should equal "Yes"

@"記事制作用"
Pa
|> Array.map (fun p -> Qa |> Array.map (fun q -> p+q))
|> Array.concat
|> Array.filter (fun x -> x=K)
|> Array.isEmpty
|> fun b -> if b then "No" else "Yes"

Pa
|> Array.collect (fun p -> Qa |> Array.map (fun q -> p+q))
|> Array.filter (fun x -> x=K)
|> Array.isEmpty
|> fun b -> if b then "No" else "Yes"

Pa
|> Array.collect (fun p -> Qa |> Array.choose (fun q ->
   let s = p+q
   if s=K then Some s else None))
|> Array.isEmpty
|> fun b -> if b then "No" else "Yes"

Pa
|> Array.collect (fun p -> Qa |> Array.choose (fun q -> let s = p+q in if s=K then Some s else None))
|> Array.isEmpty
|> fun b -> if b then "No" else "Yes"
