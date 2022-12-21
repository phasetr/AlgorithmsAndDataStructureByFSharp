#r "nuget: FsUnit"
open FsUnit

(*
let N,Ia = 3,[|(1,2);(2,3)|]
let N,Ia = 8,[|(1,2);(2,3);(2,4);(2,5);(4,7);(5,6);(6,8)|]
let N,Ia = 6,[|(1,2);(1,3);(1,4);(1,5);(1,6)|]
*)
let solve N Ia =
  let Ga =
    ((0, Array.init N (fun _ -> List.empty)), Ia)
    ||> Array.fold (fun (e,Ga) (a,b) -> Ga.[a-1] <- (e,b-1)::Ga.[a-1]; Ga.[b-1] <- (e,a-1)::Ga.[b-1]; (e+1,Ga))
    |> snd

  let rec dfs pi ci color Xa =
    let Cq = Ga.[ci] |> List.filter (snd >> (<>) pi) |> Seq.zip (Seq.initInfinite ((+) 1) |> Seq.filter ((<>) color))
    (Xa, Cq) ||> Seq.fold (fun Xa (color,(e,gci)) -> dfs ci gci color (Array.set Xa e color; Xa))
  Array.zeroCreate (N-1) |> dfs 0 0 0
  |> fun Xa -> Array.append [|Array.max Xa|] Xa

let N = stdin.ReadLine() |> int
let Ia = Array.init (N-1) (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1])
solve N Ia |> Array.iter (stdout.WriteLine)

solve 3 [|(1,2);(2,3)|] |> Seq.iter (stdout.WriteLine)
// [|2;1;2|]
solve 8 [|(1,2);(2,3);(2,4);(2,5);(4,7);(5,6);(6,8)|] |> Seq.iter (stdout.WriteLine)
// [|4;1;2;3;4;1;1;2|]
solve 6 [|(1,2);(1,3);(1,4);(1,5);(1,6)|] |> Seq.iter (stdout.WriteLine)
// [|5;1;2;3;4;5|]

let forStudy N Ia =
  let Ga =
    ((0, Array.init N (fun _ -> List.empty)), Ia)
    ||> Array.fold (fun (e,Ga) (a,b) -> Ga.[a-1] <- (e,b-1)::Ga.[a-1]; Ga.[b-1] <- (e,a-1)::Ga.[b-1]; (e+1,Ga))
    |> snd

  printfn "Ga: %A" Ga
  let rec dfs pi ci color Xa =
    let Cq = Ga.[ci] |> List.filter (snd >> (<>) pi) |> Seq.zip (Seq.initInfinite ((+) 1) |> Seq.filter ((<>) color))
    printfn ""
    printfn "(pi,ci,color,Xa): %A" (pi,ci,color,Xa)
    printfn "Ga.[ci]: %A" Ga.[ci]
    printfn "Cq: %A" Cq
    (Xa, Cq) ||> Seq.fold (fun Xa (color,(e,gci)) ->
                           printfn "(pi,ci,colorInFold,e,gci): %A" (pi,ci,color,e,gci)
                           dfs ci gci color (Array.set Xa e color; Xa))
  Array.zeroCreate (N-1) |> dfs 0 0 0
  |> fun Xa -> Array.append [|Array.max Xa|] Xa

#r "nuget: FsUnit"
open FsUnit
Seq.zip [1..4] [11..15] |> should equal [(1,11);(2,12);(3,13);(4,14)]
