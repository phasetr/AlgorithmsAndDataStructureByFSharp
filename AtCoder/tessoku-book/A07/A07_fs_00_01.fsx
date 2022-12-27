#r "nuget: FsUnit"
open FsUnit

(*
let D,N,Ia = 8,5,[|(2,3);(3,6);(5,7);(3,7);(1,5)|]
*)
let solve D N Ia =
  (Array.create D 0, Ia) ||> Array.fold (fun Na (l,r) ->
    for i in l-1..r-1 do Na.[i] <- Na.[i]+1
    Na)

let D = stdin.ReadLine() |> int
let N = stdin.ReadLine() |> int
let Ia = Array.init N (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1])
solve D N Ia |> Array.iter stdout.WriteLine

solve 8 5 [|(2,3);(3,6);(5,7);(3,7);(1,5)|] |> should equal [|1;2;4;3;4;3;2;0|]
