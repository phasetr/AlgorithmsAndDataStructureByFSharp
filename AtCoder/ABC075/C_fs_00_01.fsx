#r "nuget: FsUnit"
open FsUnit

// let N,M,Xa = 7,7,[|[|1;3|];[|2;7|];[|3;4|];[|4;5|];[|4;6|];[|5;6|];[|6;7|]|]
let solve N M (Xa:int[][]) =
  let mutable c = 0
  for x in Xa do
    let mutable l = [0..N-1]
    for y in Xa do
      if y<>x then l <- [ for i in [0..N-1] do if l.[i]=l.[y.[1]-1] then l.[y.[0]-1] else l.[i] ]
    l |> List.distinct |> List.length |> fun len -> if len<>1 then c <- c+1
  c

let N,M = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Xa = Array.init M (fun _ -> stdin.ReadLine().Split() |> Array.map int)
solve N M Xa |> stdout.WriteLine

solve 7 7 [|[|1;3|];[|2;7|];[|3;4|];[|4;5|];[|4;6|];[|5;6|];[|6;7|]|] |> should equal 4
solve 3 3 [|[|1;2|];[|1;3|];[|2;3|]|] |> should equal 0
solve 6 5 [|[|1;2|];[|2;3|];[|3;4|];[|4;5|];[|5;6|]|] |> should equal 5
