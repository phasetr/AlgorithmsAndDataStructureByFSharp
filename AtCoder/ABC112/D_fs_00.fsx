#r "nuget: FsUnit"
open FsUnit

let N,M = 3,14
let solve N M =
  let m = M/N
  let sqM = M |> double |> sqrt |> ceil |> int
  [|1..sqM|] |> Array.collect (fun x -> if M%x=0 then [|x;M/x|] else [||])
  |> Array.filter ((>=) m)
  |> Array.max

let N,M = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
solve N M |> stdout.WriteLine

solve 3 14 |> should equal 2
solve 10 123 |> should equal 3
solve 100000 1000000000 |> should equal 10000
