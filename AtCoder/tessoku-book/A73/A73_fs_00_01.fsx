#r "nuget: FsUnit"
open FsUnit

(*
let N,M,Ia = 3,3,[|(1,2,70,1);(2,3,20,1);(1,3,90,0)|]
*)
type Heap<'a> = Empty | HP of 'a * int * Heap<'a> * Heap<'a>
let empty = Empty
let isEmpty = function | Empty -> true | _ -> false
let singleton x = HP(x,1,Empty,Empty)
let find = function | Empty -> failwith "find: empty heap" | HP (x,_,_,_) -> x
let rank = function | Empty -> 0 | HP (_,r,_,_) -> r
let create x a b = if rank a >= rank b then HP(x, rank b + 1, a, b) else HP(x, rank a + 1, b, a)
let rec merge h1 h2 =
  match h1, h2 with
    | h1, Empty -> h1
    | Empty, h2 -> h2
    | HP (x1, _, a1, b1), HP (x2, _, a2, b2) ->
      if x1 <= x2 then create x1 a1 (merge b1 h2) else create x2 a2 (merge h1 b2)
let insert x h = merge (singleton x) h
let delete = function | Empty -> failwith "delete: empty heap" | HP (x,_,a,b) -> merge a b
let ofList xs = (Empty,xs) ||> List.fold (fun h x -> insert x h)
let rec toList = function | Empty -> [] | h -> let x = find h in x::(delete h |> toList)

let solve N M Ia =
  let edge = (Array.create N [], Ia) ||> Array.fold (fun g (a,b,c,d) ->
    let c0 = (int64 c)*10000L - (int64 d)
    g.[a-1] <- (c0,b-1)::g.[a-1]
    g.[b-1] <- (c0,a-1)::g.[b-1]
    g)
  let Da =
    let Da = Array.create N System.Int64.MaxValue |> fun x -> x.[0] <- 0L; x
    let visited = Array.create N false |> fun x -> x.[0] <- true; x
    let rec dijkstra = function
      | Empty -> ()
      | h ->
        let c,v = find h
        let h' = delete h
        if visited.[v] then dijkstra h'
        else
          visited.[v] <- true
          let m = min Da.[v] c
          Da.[v] <- m
          (h', edge.[v]) ||> List.fold (fun fh (fx,fv) -> insert (fx+m,fv) fh) |> dijkstra
    edge.[0] |> ofList |> dijkstra
    Da
  let d = Da.[N-1]
  ((d+9999L)/10000L, 10000L-(d%10000L))

let N,M = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Ia = Array.init M (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1],x.[2],x.[3])
solve N M Ia |> fun (x,y) -> [|string x; string y|] |> String.concat " " |> stdout.WriteLine

solve 3 3 [|(1,2,70,1);(2,3,20,1);(1,3,90,0)|] |> should equal (90L,2L)
