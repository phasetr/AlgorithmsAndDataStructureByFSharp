#r "nuget: FsUnit"
open FsUnit

let solve n m l (Aa:int[,]) (Ba:int[,]) =
  let mutable Ca = Array2D.zeroCreate n l
  for i in 0..n-1 do
    for j in 0..l-1 do
      Ca.[i,j] <- (0,[|0..m-1|]) ||> Array.fold (fun acc k -> acc + Aa.[i,k]*Ba.[k,j])
    done
  done
  Ca

let n,m,l = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1],x.[2])
let Aa = [| for i in 1..n do (stdin.ReadLine().Split() |> Array.map int) |] |> array2D
let Ba = [| for i in 1..m do (stdin.ReadLine().Split() |> Array.map int) |] |> array2D
solve n m l Aa Ba |> stdout.WriteLine

let (n,m,l) = (3,2,3)
let Aa = array2D [|[|1;2|];[|0;3|];[|4;5|]|]
let Ba = array2D [|[|1;2;1|];[|0;3;2|]|]
solve n m l Aa Ba |> should equal (array2D [|[|1;8;5|];[|0;9;6|];[|4;23;14|]|])
