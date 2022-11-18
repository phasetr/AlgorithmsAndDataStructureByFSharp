#r "nuget: FsUnit"
open FsUnit

let N,K = 3,2
let solve N K =
  if K%2=1 then pown (N/K) 3
  else pown (N/K) 3 + pown ((N+(K/2))/K) 3

let N,K = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
solve N K |> stdout.WriteLine

solve 3 2 |> should equal 9
solve 5 3 |> should equal 1
solve 31415 9265 |> should equal 27
solve 35897 932 |> should equal 114191
