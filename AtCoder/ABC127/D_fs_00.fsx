#r "nuget: FsUnit"
open FsUnit

let N,M,Aa,Xa = 3,2,[|5L;1L;4L|],[|(2L,3L);(1L,5L)|]
let solve N M Aa Xa =
  Aa |> Array.map (fun x -> (1L,x))
  |> fun a -> Array.append a Xa
  |> Array.sortByDescending snd
  |> Array.fold (fun (sum,k) (b,c) ->
    if k=0L then (sum,0L)
    else if k<b then (sum + k*c, 0L)
    else (sum + b*c, k-b)) (0L,int64 N)
  |> fst

let N,M = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Aa = stdin.ReadLine().Split() |> Array.map int64
let Xa = [| for i in 1..M do (stdin.ReadLine().Split() |> Array.map int64 |> (fun x -> x.[0],x.[1])) |]
solve N M Aa Xa |> stdout.WriteLine

solve 3 2 [|5L;1L;4L|] [|(2L,3L);(1L,5L)|] |> should equal 14L
solve 10 3 [|1L;8L;5L;7L;100L;4L;52L;33L;13L;5L|] [|3L,10L;4L,30L;1L,4L;|] |> should equal 338L
solve 3 2 [|100L;100L;100L|] [|(3L,99L);(3L,99L)|] |> should equal 300L
solve 11 3 [|1L;1L;1L;1L;1L;1L;1L;1L;1L;1L;1L|] [|3L,1000000000L;4L,1000000000L;3L,1000000000L|] |> should equal 10000000001L
