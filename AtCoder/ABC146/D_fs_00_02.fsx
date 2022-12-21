#r "nuget: FsUnit"
open FsUnit

(*
let N,Ia = 3,[|(1,2);(2,3)|]
let N,Ia = 8,[|(1,2);(2,3);(2,4);(2,5);(4,7);(5,6);(6,8)|]
let N,Ia = 6,[|(1,2);(1,3);(1,4);(1,5);(1,6)|]
*)

let solve N Ia =
  let Ga =
    ((1, Array.init N (fun _ -> List.empty)), Ia)
    ||> Array.fold (fun (i,Ga) (a,b) -> Ga.[a-1] <- (i,b-1)::Ga.[a-1]; Ga.[b-1] <- (i,a-1)::Ga.[b-1]; (i+1,Ga))
    |> snd

  let rec dfs pi ci color Xm =
    let Cq = Ga.[ci] |> List.filter (snd >> (<>) pi) |> Seq.zip (Seq.initInfinite ((+) 1) |> Seq.filter ((<>) color))
    (Xm, Cq) ||> Seq.fold (fun Xm (color,(j,gci)) -> dfs ci gci color (Xm |> Map.add j color))
  Map.empty |> dfs 0 0 0
  // |> fun Xm -> let vq = Xm.Values in Seq.append (seq { Seq.max vq }) vq // Map.ValuesはF#6から
  |> fun Xm -> let vq = Xm |> Map.toSeq |> Seq.map snd in Seq.append (seq { Seq.max vq }) vq

let N = stdin.ReadLine() |> int
let Ia = Array.init (N-1) (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1])
solve N Ia |> Seq.iter (stdout.WriteLine)

solve 3 [|(1,2);(2,3)|] |> Seq.iter (stdout.WriteLine)
// [|2;1;2|]
solve 8 [|(1,2);(2,3);(2,4);(2,5);(4,7);(5,6);(6,8)|] |> Seq.iter (stdout.WriteLine)
// [1;4;3;2;1;1;2]
solve 6 [|(1,2);(1,3);(1,4);(1,5);(1,6)|] |> Seq.iter (stdout.WriteLine)
// [|5;1;2;3;4;5|]
