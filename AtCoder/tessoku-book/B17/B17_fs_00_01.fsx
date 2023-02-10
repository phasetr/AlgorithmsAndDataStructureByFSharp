#r "nuget: FsUnit"
open FsUnit

(*
let N,Ha = 4,[|10;30;40;20|]
let N,Ha = 2,[|10;10|]
let N,Ha = 6,[|30;10;60;10;60;50|]
*)
let solve N (Ha:int[]) =
  Array.init N (fun _ -> (0,[1]):(int*list<int>))
  |> fun dp ->
    dp.[1] <- (abs(Ha.[0]-Ha.[1]),[2;1])
    (dp,[|2..N-1|]) ||> Array.fold (fun dp i ->
      let c1 = fst dp.[i-1] + abs(Ha.[i]-Ha.[i-1])
      let c2 = fst dp.[i-2] + abs(Ha.[i]-Ha.[i-2])
      dp.[i] <- if c1<c2 then (c1,(i+1)::snd dp.[i-1]) else (c2,(i+1)::snd dp.[i-2])
      dp)
  |> Array.last |> snd |> List.rev

let N = stdin.ReadLine() |> int
let Ha = stdin.ReadLine().Split() |> Array.map int
solve N Ha |> fun l -> stdout.WriteLine l.Length; l |> List.map string |> String.concat " " |> stdout.WriteLine

solve 4 [|10;30;40;20|] |> should equal [1;2;4]
solve 2 [|10;10|] |> should equal [1;2]
solve 6 [|30;10;60;10;60;50|] |> should equal [1;3;5;6]
