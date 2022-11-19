#r "nuget: FsUnit"
open FsUnit

let N,Aa = 3,[|[|(2,1)|];[|(1,1)|];[|(2,0)|]|]
let solve N Aa =
  let f xs ys = xs |> List.collect (fun x -> [x::ys])
  [[]]
  |> List.fold (<<) id (List.replicate N (List.collect (f [0;1])))
  |> List.filter (fun xs ->
    let Xa = xs |> List.toArray
    (true, [|0..N-1|], Aa)
    |||> Array.fold2 (fun b i xya ->
      if Xa.[i]=1 then (b,xya) ||> Array.fold (fun b (x,y) -> if Xa.[x-1]=y then b else false)
      else b))
  |> List.map List.sum |> List.max

let N = stdin.ReadLine() |> int
let Aa = Array.init N (fun _ -> Array.init (stdin.ReadLine() |> int) (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1]))
solve N Aa |> stdout.WriteLine

solve 3 [|[|(2,1)|];[|(1,1)|];[|(2,0)|]|] |> should equal 2
solve 3 [|[|(2,1);(3,0)|];[|(3,1);(1,0)|];[|(1,1);(2,0)|]|] |> should equal 0
solve 2 [|[|(2,0)|];[|(1,0)|]|] |> should equal 1
