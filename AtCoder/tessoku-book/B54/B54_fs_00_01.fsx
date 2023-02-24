#r "nuget: FsUnit"
open FsUnit

(*
let N,Aa = 6,[|30;10;30;20;10;30|]
*)
let solve N Aa =
  Aa |> Array.sort |> fun Aa ->
    ((0L,0L), [|1..N-1|])
    ||> Array.fold (fun (a,c) i -> if Aa.[int c]=Aa.[i] then (a+((int64 i)-c),c) else (a,int64 i))
  |> fst
let N = stdin.ReadLine() |> int
let Aa = Array.init N (fun _ -> stdin.ReadLine() |> int64)
solve N Aa |> stdout.WriteLine

solve 6 [|30L;10L;30L;20L;10L;30L|] |> should equal 4L
