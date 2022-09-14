#r "nuget: FsUnit"
open FsUnit

let solve N (Aa: int[][]) =
  let a = Array2D.zeroCreate N N
  for i = 0 to N-1 do
    let (id, k) = Aa.[i].[0],Aa.[i].[1]
    [|0..k-1|] |> Array.iter (fun j -> a.[id-1,Aa.[i].[j+2]-1] <- 1)
  done
  a

let N = stdin.ReadLine() |> int
let Aa = [| for i in 1..N do (stdin.ReadLine().Split() |> Array.map int) |]
solve N Aa |> fun x -> ([|0..N-1|] |> Array.iter (fun i -> sol.[i,*] |> Array.map string |> String.concat " " |> stdout.WriteLine))

let N,Aa = 4,[|[|1;2;2;4|];[|2;1;4|];[|3;0|];[|4;1;3|]|]
solve N Aa |> should equal (array2D [[0;1;0;1];[0;0;0;1];[0;0;0;0];[0;0;1;0]])
