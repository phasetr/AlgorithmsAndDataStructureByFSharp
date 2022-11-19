#r "nuget: FsUnit"
open FsUnit

let N,Aa = 3,[|[|(2,1)|];[|(1,1)|];[|(2,0)|]|]
let N,Aa = 3,[|[|(2,1);(3,0)|];[|(3,1);(1,0)|];[|(1,1);(2,0)|]|]
let solve N (Aa:(int*int)[][]) =
  let rec powerset = function | [] -> [[]] | h::t -> List.fold (fun xs t -> (h::t)::t::xs) [] (powerset t)
  powerset [1..N]
  |> List.filter (fun zs ->
    zs
    |> List.map (fun i -> Aa.[i-1] |> Array.map (fun (x,y) -> y=0 <> List.contains x zs) |> Array.forall id)
    |> List.forall id)
  |> List.map List.length |> List.max

let N = stdin.ReadLine() |> int
let Aa = Array.init N (fun _ -> Array.init (stdin.ReadLine() |> int) (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1]))
solve N Aa |> stdout.WriteLine

solve 3 [|[|(2,1)|];[|(1,1)|];[|(2,0)|]|] |> should equal 2
solve 3 [|[|(2,1);(3,0)|];[|(3,1);(1,0)|];[|(1,1);(2,0)|]|] |> should equal 0
solve 2 [|[|(2,0)|];[|(1,0)|]|] |> should equal 1
