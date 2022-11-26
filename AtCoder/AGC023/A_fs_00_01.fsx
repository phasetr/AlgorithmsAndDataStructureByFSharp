#r "nuget: FsUnit"
open FsUnit

let N,Aa = 6,[|1L;3L;-4L;2L;2L;-2L|]
let solveTLE N Aa =
  let mutable num,acc = 0,0L
  for i in 0..N-1 do
    acc <- 0L
    Aa |> Array.skip i |> Array.iter (fun a -> acc <- acc+a; if acc=0L then num<-num+1)
  num

let N,Aa = 7,[|1L;-1L;1L;-1L;1L;-1L;1L|]
let solve N Aa =
  (0L,Aa) ||> Array.scan (fun acc a -> acc+a)
  |> Array.groupBy id
  |> Array.sumBy (fun (_,a) -> let n = Array.length a |> int64 in n*(n-1L)/2L)

let N = stdin.ReadLine() |> int
let Aa = stdin.ReadLine().Split() |> Array.map int64
solve N Aa |> stdout.WriteLine

solve 6 [|1L;3L;-4L;2L;2L;-2L|] |> should equal 3L
solve 7 [|1L;-1L;1L;-1L;1L;-1L;1L|] |> should equal 12L
solve 5 [|1L;-2L;3L;-4L;5L|] |> should equal 0L
