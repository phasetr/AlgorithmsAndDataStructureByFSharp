#r "nuget: FsUnit"
open FsUnit

let N,Aa = 3,[|3L;1L;4L|]
let N,Aa = 5,[|1L;1L;1L;1L;1L|]
let N,Aa = 6,[|40L;1L;30L;2L;7L;20L|]
let solveTLE N Aa =
  let Xs = Aa |> Array.sort |> Array.toList
  let rec frec acc minAcc = function
    | [] -> acc
    | [x] -> acc
    | y::ys as xs ->
      let b = ((true,minAcc+y), ys) ||> List.fold (fun (b,n) x -> if b && x<=2*n then (true,n+x) else (false,n)) |> fst
      frec (if b then acc else acc-1) (minAcc+y) ys
  Xs |> frec N 0

let solve N Aa =
  let Xa = Aa |> Array.sort
  let Ya = (0L,Xa) ||> Array.scan (+) |> Array.tail
  (0,(Array.tail Xa),Ya) |||> Seq.fold2 (fun acc x y -> if x>y*2L then 0 else acc+1) |> (+) 1

let N = stdin.ReadLine() |> int
let Aa = stdin.ReadLine().Split() |> Array.map int64
solve N Aa |> stdout.WriteLine

solve 3 [|3L;1L;4L|] |> should equal 2
solve 5 [|1L;1L;1L;1L;1L|] |> should equal 5
solve 6 [|40L;1L;30L;2L;7L;20L|] |> should equal 4
