#r "nuget: FsUnit"
open FsUnit

let N,Aa = 3,[|[|(2,1)|];[|(1,1)|];[|(2,0)|]|]
let solve N Aa =
  let xss =
    let f xs = [false::xs;true::xs]
    [[]] |> List.fold (<<) id (List.replicate N (List.collect f))
  let f xs =
    let Xa = xs |> List.toArray
    let mutable b = true
    Aa |> Array.iteri (fun i xya -> if Xa.[i]=1 then for (x,y) in xya do if Xa.[x-1]<>y then b <- false)
    b
  List.filter f xss |> List.map List.sum |> List.max

let N = stdin.ReadLine() |> int
let Aa = Array.init N (fun _ -> Array.init (stdin.ReadLine() |> int) (fun _ -> stdin.ReadLine().Split() |> Array.map int))
solve N Aa |> stdout.WriteLine

solve 3 [|[|(2,1)|];[|(1,1)|];[|(2,0)|]|] |> should equal 2
solve 3 [|[|(2,1);(3,0)|];[|(3,1);(1,0)|];[|(1,1);(2,0)|]|] |> should equal 0
solve 2 [|[|(2,0)|];[|(1,0)|]|] |> should equal 1
