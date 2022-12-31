#r "nuget: FsUnit"
open FsUnit

(*
let N,Ia = 4,[|(4,20);(3,30);(2,40);(1,10)|]
let N,Ia = 8,[|(8,100);(7,100);(6,100);(5,100);(4,100);(3,100);(2,100);(1,100)|]
*)
let solve N (Ia:(int*int)[]) =
  let score l r (p,a) = if l<=p-1 && p-1<r then a else 0
  (Array2D.create (N+1) (N+1) 0, [|N..(-1)..0|])
  ||> Array.fold (fun dp r ->
    [|0..r-1|] |> Array.iter (fun l ->
      dp.[l+1,r] <- max dp.[l+1,r] (dp.[l,r] + score l r Ia.[l])
      dp.[l,r-1] <- max dp.[l,r-1] (dp.[l,r] + score l r Ia.[r-1]))
    dp)
  |> fun dp -> [|0..N|] |> Array.map (fun i -> dp.[i,i]) |> Array.max

let N = stdin.ReadLine() |> int
let Ia = Array.init N (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1])
solve N Ia |> stdout.WriteLine

solve 4 [|(4,20);(3,30);(2,40);(1,10)|] |> should equal 60
solve 8 [|(8,100);(7,100);(6,100);(5,100);(4,100);(3,100);(2,100);(1,100)|] |> should equal 400

@"記事執筆用"
let test N (Ia:(int*int)[]) =
  let score l r (p,a) = if l<=p-1 && p-1<r then a else 0
  (Array2D.create (N+1) (N+1) 0, [|N..(-1)..0|])
  ||> Array.fold (fun dp r ->
    [|0..r-1|] |> Array.iter (fun l ->
      printfn "%A" (l,r)
      dp.[l+1,r] <- max dp.[l+1,r] (dp.[l,r] + score l r Ia.[l])
      dp.[l,r-1] <- max dp.[l,r-1] (dp.[l,r] + score l r Ia.[r-1])
      printfn "%A" dp)
    dp)
  |> fun dp -> [|0..N|] |> Array.map (fun i -> dp.[i,i]) |> Array.max

[| for r in N..(-1)..0 do for l in 0..r-1 do (l,r) |]
|> Array.iter (fun (l,r) ->
  printfn "score %d %d (%d,%d): %d" l r (fst Ia.[l]) (snd Ia.[l]) (score l r Ia.[l])
  printfn "score %d %d (%d,%d): %d" l r (fst Ia.[r-1]) (snd Ia.[r-1]) (score l r Ia.[r-1])
              )

[| for r in N..(-1)..0 do for l in 0..r-1 do (l,r) |]
|> Array.iter (fun (l,r) ->
  printfn "score %d %d Ia[%d]: %d" l r l (score l r Ia.[l])
  printfn "score %d %d Ia[%d]: %d" l r (r-1) (score l r Ia.[r-1])
              )
