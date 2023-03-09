#r "nuget: FsUnit"
open FsUnit

(*
let N,M,Pa,Ia = 5,2,[|3;4;-1;-5;5|],[|(1,3);(2,4)|]
*)
// TODO From Haskell
open System.Collections.Generic
let solve N M Pa Ia =
  let n = N+2
  let inf = pown 10 9
  let pa = Pa |> Array.mapi (fun i p -> [|(0,i+1,max 0 p);(i+1,n-1,max 0 (-p))|]) |> Array.concat
  let abc = Array.append pa (Ia |> Array.map (fun (a,b) -> (a,b,inf)))
  let offset = Pa |> Array.filter (fun p -> p>0) |> Array.sum
  let edge0 =
    let vec = Array.init n (fun _ -> HashSet<int*int*int>())
    abc |> Array.iteri (fun e (a,b,c) ->
      vec.[a].Add(e,b,c) |> ignore
      vec.[b].Add(e,a,0) |> ignore)
    vec
  let (s,t) = (0,n-1)
  let dfs (edge:HashSet<int*int*int>[]) =
    let vec = Array.create n (-1,0,0)
    let rec go (set:HashSet<int>) = function
      | [] -> ()
      | q::qs ->
        let (_,i,z) = q
        if z = 0 then go set qs
        else
          set.Remove(i) |> ignore
          let next = edge.[i] |> Seq.filter (fun (_,k,x) -> set.Contains(k) && x>0) |> Seq.toList
          for (e,j,y) in next do vec.[j] <- (i,y,e)
          go set (next @ qs)
    go (HashSet([0..n-1])) [(0,s,1)]
    vec
  let path res =
    let func (fmin,flow)  (p,k,e,f) = (min fmin f, (p,k,e)::flow)
    let rec back k =
      if k<0 then None
      elif k=0 then Some []
      else
        let (p,f,e) = res.[k]
        back p |> Option.map (fun x -> (p,k,e,f)::x)
    back t |> Option.map (fun xs -> List.fold func (10000,[]))
  let updateEdge edge (d,flow) =
    for (a,b,e) in flow do
      let setA = edge.[a]
      let setB = edge.[b]
      let (setA', setB') =

let N,M = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Pa = stdin.ReadLine().Split() |> Array.map int
let Ia = Array.init M (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1])
solve N M Pa Ia |> stdout.WriteLine

solve 5 2 [|3;4;-1;-5;5|] [|(1,3);(2,4)|] |> should equal 7
