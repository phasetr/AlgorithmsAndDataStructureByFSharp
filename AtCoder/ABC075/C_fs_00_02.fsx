#r "nuget: FsUnit"
open FsUnit

// let N,M,Xa = 7,7,[|[|1;3|];[|2;7|];[|3;4|];[|4;5|];[|4;6|];[|5;6|];[|6;7|]|]
let solve N (Xa:int[][]) =
  (0, Xa) ||> Array.fold (fun c x ->
    ([0..N-1], Xa) ||> Array.fold (fun acc y ->
      if x=y then acc
      else
        let (a,b)=(y.[0],y.[1])
        [0..N-1] |> List.map (fun i -> if acc.[i]=acc.[b-1] then acc.[a-1] else acc.[i]))
    |> List.distinct |> List.length |> fun l -> if l=1 then c else c+1)

let N,M = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Xa = Array.init M (fun _ -> stdin.ReadLine().Split() |> Array.map int)
solve N Xa |> stdout.WriteLine

solve 7 [|[|1;3|];[|2;7|];[|3;4|];[|4;5|];[|4;6|];[|5;6|];[|6;7|]|] |> should equal 4
solve 3 [|[|1;2|];[|1;3|];[|2;3|]|] |> should equal 0
solve 6 [|[|1;2|];[|2;3|];[|3;4|];[|4;5|];[|5;6|]|] |> should equal 5
