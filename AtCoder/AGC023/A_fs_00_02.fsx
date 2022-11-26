#r "nuget: FsUnit"
open FsUnit

let N,Aq = 6,[|1L;3L;-4L;2L;2L;-2L|]
let N,Aq = 7,[|1L;-1L;1L;-1L;1L;-1L;1L|]
let solve N Aq =
  (0L,Aq) ||> Seq.scan (fun acc a -> acc+a)
  |> Seq.groupBy id
  |> Seq.sumBy (fun (_,a) -> let n = Seq.length a |> int64 in n*(n-1L)/2L)

let N = stdin.ReadLine() |> int
let Aq = stdin.ReadLine().Split() |> Seq.map int64
solve N Aq |> stdout.WriteLine

solve 6 (seq {1L;3L;-4L;2L;2L;-2L}) |> should equal 3L
solve 7 (seq {1L;-1L;1L;-1L;1L;-1L;1L}) |> should equal 12L
solve 5 (seq {1L;-2L;3L;-4L;5L}) |> should equal 0L
