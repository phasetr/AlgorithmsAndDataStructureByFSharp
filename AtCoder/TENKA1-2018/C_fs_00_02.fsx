#r "nuget: FsUnit"
open FsUnit

// let N,Aa = 5,[|6L;8L;1L;2L;3L|]
let solve N Aa =
  let Sa = Aa |> Array.sort
  if N%2=0 then 2L*(Array.sum Sa.[N/2..] - Array.sum Sa.[0..N/2-1]) - Sa.[N/2] + Sa.[N/2-1]
  else 2L*(Array.sum Sa.[N/2+1..] - Array.sum Sa.[0..N/2-1]) + max (Sa.[N/2]-Sa.[N/2+1]) (Sa.[N/2-1]-Sa.[N/2])

let N = stdin.ReadLine() |> int
let Aa = Array.init N (fun _ -> stdin.ReadLine() |> int64)
solve N Aa |> stdout.WriteLine

solve 5 [|6L;8L;1L;2L;3L|] |> should equal 21L
solve 6 [|3L;1L;4L;1L;5L;9L|] |> should equal 25L
solve 3 [|5L;5L;1L|] |> should equal 8L
