#r "nuget: FsUnit"
open FsUnit

(*
let Q,Qa = 5,[|(2,30);(1,10);(2,30);(1,40);(2,30)|]
let Q,Qa = 10,[|(2,877914575);(2,24979445);(2,623690081);(1,476190629);(1,211047202);(1,628894325);(2,822804784);(1,430302156);(2,161735902);(2,923078537)|]
*)
open System.Collections.Generic
let solve Q Qa =
  let maxNumber = 1000000001
  let add item (l:List<int>) =
    if l.Count=0 then l.Add(item) else let j = l.BinarySearch(item) in l.Insert(~~~j,item)
  let lowerBound item (l:List<int>) =
    l.BinarySearch(item)
    |> fun s -> if 0<=s then s else ~~~s
    |> fun s -> if s<l.Count then s else -1
  let upperBound item (l:List<int>) =
    l.BinarySearch(item)
    |> fun s -> if 0<=s then s else ~~~s-1
    |> fun s -> if 0<=s then s else -1
  let ls = List<int>()
  ([],Qa) ||> Array.fold (fun acc (q,x) ->
    if q=1 then add x ls; acc
    elif ls.Count=0 then (-1)::acc
    else
      let lb,ub = lowerBound x ls, upperBound x ls
      let dl = if 0<=lb then ls.[lb] - x else maxNumber
      let du = if 0<=ub then x - ls.[ub] else maxNumber
      (min dl du)::acc)
  |> List.rev

let Q = stdin.ReadLine() |> int
let Qa = Array.init Q (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1])
solve Q Qa |> List.iter stdout.WriteLine

solve 5 [|(2,30);(1,10);(2,30);(1,40);(2,30)|] |> should equal [-1;20;10]
// random01.in
solve 10 [|(2,877914575);(2,24979445);(2,623690081);(1,476190629);(1,211047202);(1,628894325);(2,822804784);(1,430302156);(2,161735902);(2,923078537)|] |> should equal [-1;-1;-1;193910459;49311300;294184212]
