#r "nuget: FsUnit"
open FsUnit

(*
let N,Aa,Ba = 7,[|2;4;4;7;6;7|],[|3;5;6;7;7;7|]
let N,Aa,Ba = 2,[|2|],[|2|]
let N,Aa,Ba = 4,[|2;4;4|],[|2;4;4|]
let N,Aa,Ba = 7,[|2;7;7;7;4;7|],[|2;7;6;7;7;7|]
*)
let solve N (Aa:int[]) (Ba:int[]) =
  Array.create (N+1) (System.Int64.MinValue)
  |> fun dp -> dp.[1] <- 0L; dp
  |> fun dp -> (dp, [|1..N-1|]) ||> Array.fold (fun dp i ->
    dp.[Aa.[i-1]] <- max dp.[Aa.[i-1]] (dp.[i] + 100L)
    dp.[Ba.[i-1]] <- max dp.[Ba.[i-1]] (dp.[i] + 150L)
    dp)
  |> Array.last

let N = stdin.ReadLine() |> int
let Aa = stdin.ReadLine().Split() |> Array.map int
let Ba = stdin.ReadLine().Split() |> Array.map int
solve N Aa Ba |> stdout.WriteLine

solve 7 [|2;4;4;7;6;7|] [|3;5;6;7;7;7|] |> should equal 500L
solve 2 [|2|] [|2|] |> should equal 150L
solve 4 [|2;4;4|] [|2;4;4|] |> should equal 300L
solve 7 [|2;7;7;7;4;7|] [|2;7;6;7;7;7|]
