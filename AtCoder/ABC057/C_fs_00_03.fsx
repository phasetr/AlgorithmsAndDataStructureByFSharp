#r "nuget: FsUnit"
open FsUnit

let N = 10000L
let N = 9876543210L
let solve N =
  let sqrtN = N |> float |> sqrt |> int64
  let isPrime n =  [|2L..sqrtN|] |> Array.forall (fun x -> n%x<>0L)
  let sLen s = s |> string |> String.length
  if isPrime N then sLen N
  else [|2L..sqrtN+1L|] |> Array.choose (fun x -> if N%x=0L then Some (N/x) else None) |> Array.min |> sLen

let N = stdin.ReadLine() |> int64
solve N |> stdout.WriteLine

solve 10000L |> should equal 3
solve 1000003L |> should equal 7
solve 9876543210L |> should equal 6
