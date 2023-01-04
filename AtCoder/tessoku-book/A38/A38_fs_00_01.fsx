#r "nuget: FsUnit"
open FsUnit

(*
let D,N,Ia = 5,3,[|(1,2,22);(2,3,16);(3,5,23)|]
*)
let solve D N Ia =
  (Array.create (D+1) 24,Ia)
  ||> Array.fold (fun dp (l,r,h) ->
    [|l..r|] |> Array.iter (fun i -> dp.[i] <- min dp.[i] h); dp)
  |> Array.tail |> Array.sum

let D,N = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Ia = Array.init N (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1],x.[2])
solve D N Ia |> stdout.WriteLine

solve 5 3 [|(1,2,22);(2,3,16);(3,5,23)|] |> should equal 100
