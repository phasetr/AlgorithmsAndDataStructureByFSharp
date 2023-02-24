#r "nuget: FsUnit"
open FsUnit

(*
let N,Aa = 6,[|30;10;30;20;10;30|]
*)
let solveOutOfMemory N Aa =
  let Da = Array.create (1_000_000_001) 0L
  (0L,Aa) ||> Array.fold (fun acc a -> Da.[a] <- Da.[a]+1L; acc+Da.[a]-1L)

let solve N Aa =
  let D = System.Collections.Generic.Dictionary<int,int64>()
  (0L,Aa) ||> Array.fold (fun acc a ->
    D.TryGetValue(a) |> function
      | true,v -> D.[a] <- D.[a]+1L; acc+D.[a]-1L
      | false,_ -> D.Add(a,1L); acc)
let N = stdin.ReadLine() |> int
let Aa = Array.init N (fun _ -> stdin.ReadLine() |> int)
solve N Aa |> stdout.WriteLine

solve 6 [|30;10;30;20;10;30|] |> should equal 4L
