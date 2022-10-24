#r "nuget: FsUnit"
open FsUnit

let N = 10000L
let N = 9876543210L
let solve N =
  let g x = x |> string |> String.length
  let f a b = max (g a) (g b)
  [| for i in 1L..100000L do if N%i=0L then yield f i (N/i) |] |> Array.min

let N = stdin.ReadLine() |> int64
solve N |> stdout.WriteLine

solve 10000L |> should equal 3
solve 1000003L |> should equal 7
solve 9876543210L |> should equal 6
