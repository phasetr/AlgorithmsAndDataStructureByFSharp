#r "nuget: FsUnit"
open FsUnit

(*
let N,W,Ia = 4,7,[|(3,13L);(3,17L);(5,29L);(1,10L)|]
let N,W,Ia = 4,100,[|(25,47L);(25,53L);(25,62L);(25,88L)|]
let N,W,Ia = 10,285,[|(29,8000L);(43,11000L);(47,10000L);(51,13000L);(52,16000L);(66,14000L);(72,25000L);(79,18000L);(82,23000L);(86,27000L)|]
*)
let solve N W Ia =
  (Array.create (W+1) 0L, Ia)
  ||> Array.fold (fun dp (w,v) ->
    [|0..W|] |> Array.map (fun w0 -> if w0<w then dp.[w0] else max (dp.[w0-w]+v) dp.[w0]))
  |> Array.last

let N,W = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Ia = Array.init N (fun _ -> stdin.ReadLine().Split() |> fun x -> int x.[0],int64 x.[1])
solve N W Ia |> stdout.WriteLine

solve 4 7 [|(3,13L);(3,17L);(5,29L);(1,10L)|] |> should equal 40
solve 4 100 [|(25,47L);(25,53L);(25,62L);(25,88L)|] |> should equal 250
solve 10 285 [|(29,8000L);(43,11000L);(47,10000L);(51,13000L);(52,16000L);(66,14000L);(72,25000L);(79,18000L);(82,23000L);(86,27000L)|] |> should equal 87000
