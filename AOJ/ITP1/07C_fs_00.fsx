#r "nuget: FsUnit"
open FsUnit

let solve r c (xa:int[,]) =
  let mutable aa = Array2D.create (r+1) (c+1) 0
  for i in 0..r do
    for j in 0..c do
      match (i,j) with
        | i,j when i=r && j=c -> aa.[i,j] <- Array.sum aa.[*,j]
        | i,_ when i=r -> aa.[i,j] <- Array.sum xa.[*,j]
        | _,j when j=c -> aa.[i,j] <- Array.sum xa.[i,*]
        | _ -> aa.[i,j] <- xa.[i,j]
      done
  done
  aa

let r,c = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let xa = [| for i in 1..N do (stdin.ReadLine().Split() |> Array.map int) |] |> array2D
solve rc xa |> stdout.WriteLine

let r,c = 4,5
let xa = [|[|1;1;3;4;5|];[|2;2;2;4;5|];[|3;3;0;1;1|];[|2;3;4;4;6|]|] |> array2D
solve r c xa |> should equal (array2D [|[|1;1;3;4;5;14|];[|2;2;2;4;5;15|];[|3;3;0;1;1;8|];[|2;3;4;4;6;19|];[|8;9;9;13;17;56|]|])
