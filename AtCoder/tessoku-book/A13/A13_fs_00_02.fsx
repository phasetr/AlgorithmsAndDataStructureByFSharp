#r "nuget: FsUnit"
open FsUnit

(*
let N,K,Ia = 7,10L,[|11L;12L;16L;22L;27L;28L;31L|]
let N,K,Ia = 5,1L,[|1L..5L|]
let N,K,Ia = 3,1L,[|1L;2L;4L|]
*)
let solveTLE N K (Ia:int64[]) =
  [|0..N-1|] |> Array.sumBy (fun i ->
    if i=N-1 then 0
    else
      Ia.[i+1..]
      |> Array.tryFindIndex (fun v -> K<v-Ia.[i])
      |> function | Some k -> k | _ -> N-i-1)

let N,K = stdin.ReadLine().Split() |> (fun x -> int x.[0], int64 x.[1])
let Ia = stdin.ReadLine().Split() |> Array.map int64
solve N K Ia |> stdout.WriteLine

solve 7 10L [|11L;12L;16L;22L;27L;28L;31L|] |> should equal 11L
solve 5 1L [|1L..5L|] |> should equal 4L
solve 3 1L [|1L;2L;4L|] |> should equal 1L
solve 1 1L [|1L|] |> should equal 0L
solve 1 2L [|1L|] |> should equal 0L
