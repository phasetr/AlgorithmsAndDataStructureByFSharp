#r "nuget: FsUnit"
open FsUnit

(*
let N,Q,Aa,Ia = 7,4,[|2;4;1;7;6;5;3|],[|(1,1);(1,5);(2,13);(5,999999999)|]
*)
let solveTLE N Q Aa Ia =
  let Ba = Aa |> Array.map (fun a -> a-1)
  let rec frec acc i j = if j=i then j::acc else frec (j::acc) i Ba.[j]
  let Ga = ((0,Array.init N (fun _ -> [])), Ba) ||> Array.fold (fun (i,g) b ->
    g.[i] <- frec [] i b; (i+1,g)) |> snd |> Array.map (List.toArray >> Array.rev)
  Ia |> Array.map (fun (x,y) -> let n = y % Array.length Ga.[x-1] in if n=0 then x else Ga.[x-1].[n-1]+1)

let solve N Q Aa Ia =
  ((0, Array.init 32 (fun _ -> Array.create (N+2) 0)), Aa)
  ||> Array.fold (fun (i,dp) a -> dp.[0].[i+1] <- a; (i+1,dp))
  |> fun (_,dp) ->
    for i in 1..31 do for j in 1..N do dp.[i].[j] <- dp.[i-1].[dp.[i-1].[j]]
    dp
  |> fun dp -> Ia |> Array.map (fun (x,y) ->
    (x, [|0..31|]) ||> Array.fold (fun p i -> if y&&&(1<<<i)>0 then dp.[i].[p] else p))

let N,Q = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Aa = stdin.ReadLine().Split() |> Array.map int
let Ia = Array.init Q (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1])
solve N Q Aa Ia |> Array.iter stdout.WriteLine

solve 7 4 [|2;4;1;7;6;5;3|] [|(1,1);(1,5);(2,13);(5,999999999)|] |> should equal [|2;1;3;6|]
