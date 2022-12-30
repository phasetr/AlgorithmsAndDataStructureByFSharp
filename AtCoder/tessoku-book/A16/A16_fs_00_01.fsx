#r "nuget: FsUnit"
open FsUnit

(*
let N,Aa,Ba = 5,[|2;4;1;3|],[|5;3;7|]
let N,Aa,Ba = 10,[|1;19;75;37;17;16;33;18;22|],[|41;28;89;74;98;43;42;31|]
*)
let solve N (Aa:int[]) (Ba:int[]) =
  (Array.create N 0, [|1..(N-1)|])
  ||> Array.fold (fun Xa i ->
    if i=1 then Xa.[i] <- Aa.[i-1] else Xa.[i] <- min (Aa.[i-1]+Xa.[i-1]) (Ba.[i-2]+Xa.[i-2])
    Xa)
  |> Array.last

let N = stdin.ReadLine() |> int
let Aa = stdin.ReadLine().Split() |> Array.map int
let Ba = stdin.ReadLine().Split() |> Array.map int
solve N Aa Ba |> stdout.WriteLine

solve 5 [|2;4;1;3|] [|5;3;7|] |> should equal 8
solve 10 [|1;19;75;37;17;16;33;18;22|] [|41;28;89;74;98;43;42;31|] |> should equal 157
