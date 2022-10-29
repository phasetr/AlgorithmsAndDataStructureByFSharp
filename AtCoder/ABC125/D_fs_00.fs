#r "nuget: FsUnit"
open FsUnit

let N,Aa = 3,[|-10L;5L;-4L|]
let solve N Aa =
  let num = Aa |> Array.filter (fun a -> a<0L) |> Array.length
  let Ba = Aa |> Array.map (fun x -> abs x)
  let s = Array.sum Ba
  if num%2=0 then s else s-2L*(Array.min Ba)

let N = stdin.ReadLine() |> int
let Aa = stdin.ReadLine().Split() |> Array.map int64
solve N Aa |> stdout.WriteLine

solve 3 [|-10L;5L;-4L|] |> should equal 19L
solve 5 [|10L;-4L;-8L;-11L;3L|] |> should equal 30L
solve 11 [|-1000000000L;1000000000L;-1000000000L;1000000000L;-1000000000L;0L;1000000000L;-1000000000L;1000000000L;-1000000000L;1000000000L|] |> should equal 10000000000L
