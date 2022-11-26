#r "nuget: FsUnit"
open FsUnit

let N = 25
let N = 100
let N = 2020
let solve N =
  let rec top = function | n when n<10 -> n | n -> top (n/10)
  (Array2D.zeroCreate 10 10, [|1..N|])
  ||> Array.fold (fun acc i -> acc.[top i,i%10] <- acc.[top i,i%10]+1; acc)
  |> fun a -> (0,[|1..N|]) ||> Array.fold (fun acc i -> acc+a.[i%10, top i])

let N = stdin.ReadLine() |> int
solve N |> stdout.WriteLine

solve 25 |> should equal 17
solve 1 |> should equal 1
solve 100 |> should equal 108
solve 2020 |> should equal 40812
solve 200000 |> should equal 400000008
