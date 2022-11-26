#r "nuget: FsUnit"
open FsUnit

let N = 8L
let solve N =
  let sqrtN = N+1L |> float |> sqrt |> int64
  [|1L..sqrtN|] |> Array.filter (fun x -> N%x=0L)
  |> Array.collect (fun x -> [|x;N/x|]) |> Array.distinct
  |> Array.filter (fun x -> x<>1L && N/(x-1L)=N%(x-1L))
  |> Array.sumBy ((+) -1L)

let N = stdin.ReadLine() |> int64
solve N |> stdout.WriteLine

solve 8L |> should equal 10L
solve 1000000000000L |> should equal 2499686339916L
