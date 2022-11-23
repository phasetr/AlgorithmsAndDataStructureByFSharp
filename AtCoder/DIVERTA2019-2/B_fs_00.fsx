#r "nuget: FsUnit"
open FsUnit

let N,Aa = 2,[|(1,1);(2,2)|]
let N,Aa = 4,[|(1,1);(1,2);(2,1);(2,2)|]
let solve N Aa =
  if N=1 then 1
  else
    Array.allPairs Aa Aa
    |> Array.choose (fun ((a,b),(x,y)) -> if a=x&&b=y then None else Some (a-x,b-y))
    |> Array.groupBy id
    |> Array.map (snd >> Array.length)
    |> Array.max
    |> (-) N

let N = stdin.ReadLine() |> int
let Aa = Array.init N (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1])
solve N Aa |> stdout.WriteLine

solve 2 [|(1,1);(2,2)|] |> should equal 1
solve 3 [|(1,4);(4,6);(7,8)|] |> should equal 1
solve 4 [|(1,1);(1,2);(2,1);(2,2)|] |> should equal 2
