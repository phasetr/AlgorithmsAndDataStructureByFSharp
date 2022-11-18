#r "nuget: FsUnit"
open FsUnit

let N,K = 3L,2L
let N,K = 5L,3L
let solve N K =
  let on = (0L,[|1L..N|]) ||> Array.fold (fun acc i -> if i%K=0L then acc+1L else acc) |> fun x -> pown x 3
  let en = if K%2L=1L then 0L else let kHalf = K/2L in (0L,[|1L..N|]) ||> Array.fold (fun acc i -> if i%K=kHalf then acc+1L else acc) |> fun x -> pown x 3
  on+en

let N,K = stdin.ReadLine().Split() |> Array.map int64 |> (fun x -> x.[0],x.[1])
solve N K |> stdout.WriteLine

solve 3L 2L |> should equal 9L
solve 5L 3L |> should equal 1L
solve 31415L 9265L |> should equal 27L
solve 35897L 932L |> should equal 114191L
