#r "nuget: FsUnit"
open FsUnit

(*
let N,Ha = 4,[|10;30;40;20|]
let N,Ha = 2,[|10;10|]
let N,Ha = 6,[|30;10;60;10;60;50|]
*)
let solve N (Ha:int[]) =
  Array.create N 0
  |> fun dp ->
    dp.[1] <- abs(Ha.[1]-Ha.[0])
    (dp, [|2..N-1|]) ||> Array.fold (fun dp i ->
      dp.[i] <- min (dp.[i-1]+abs(Ha.[i]-Ha.[i-1])) (dp.[i-2]+abs(Ha.[i]-Ha.[i-2]))
      dp)
  |> Array.last
let N = stdin.ReadLine() |> int
let Ha = stdin.ReadLine().Split() |> Array.map int
solve N Ha |> stdout.WriteLine

solve 4 [|10;30;40;20|] |> should equal 30
solve 2 [|10;10|] |> should equal 0
solve 6 [|30;10;60;10;60;50|] |> should equal 40
