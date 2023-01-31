#r "nuget: FsUnit"
open FsUnit
// See also ../DataStructures/Graph.fsx
module AdjacencyList =
  @"ResizeArrayで生成, cf. https://atcoder.jp/contests/abc157/tasks/abc157_d"
  let toAdjacencyArray N Xa =
    let Ga = Array.init N (fun _ -> ResizeArray<int>())
    Xa |> Array.iter (fun (a,b) -> Ga.[a-1].Add (b-1); Ga.[b-1].Add (a-1))
    Ga |> Array.map (fun a -> a.ToArray())
  toAdjacencyArray 5 [|(1,2);(2,3);(3,4);(3,5)|] |> should equal [|[|1|];[|0;2|];[|1;3;4|];[|2|];[|2|]|]
  toAdjacencyArray 15 [|(6,9);(9,10);(2,9);(9,12);(2,14);(1,4);(4,6);(1,3);(4,14);(1,6);(9,11);(2,6);(3,9);(5,9);(4,9);(11,15);(1,13);(4,13);(8,9);(9,13);(5,15);(3,5);(8,10);(2,4);(9,14);(1,9);(2,8);(6,13);(7,9);(9,15)|] |> should equal [|[|3;2;5;12;8|];[|8;13;5;3;7|];[|0;8;4|];[|0;5;13;8;12;1|];[|8;14;2|];[|8;3;0;1;12|];[|8|];[|8;9;1|];[|5;9;1;11;10;2;4;3;7;12;13;0;6;14|];[|8;7|];[|8;14|];[|8|];[|0;3;8;5|];[|1;3;8|];[|10;4;8|]|]

  @"リストで生成, cf. https://atcoder.jp/contests/tessoku-book/tasks/tessoku_book_bi"
  let toAdjacencyList N Ia =
    (Array.create N [], Ia)
    ||> Array.fold (fun acc (a,b) ->
      acc.[a-1] <- (b-1)::acc.[a-1]; acc.[b-1] <- (a-1)::acc.[b-1]
      acc)
  toAdjacencyList 5 [|(1,2);(2,3);(3,4);(3,5)|] |> should equal [|[1];[2;0];[4;3;1];[2];[2]|]
  toAdjacencyList 15 [|(6,9);(9,10);(2,9);(9,12);(2,14);(1,4);(4,6);(1,3);(4,14);(1,6);(9,11);(2,6);(3,9);(5,9);(4,9);(11,15);(1,13);(4,13);(8,9);(9,13);(5,15);(3,5);(8,10);(2,4);(9,14);(1,9);(2,8);(6,13);(7,9);(9,15)|] |> should equal [|[8;12;5;2;3];[7;3;5;13;8];[4;8;0];[1;12;8;13;5;0];[2;14;8];[12;1;0;3;8];[8];[1;9;8];[14;6;0;13;12;7;3;4;2;10;11;1;9;5];[7;8];[14;8];[8];[5;8;3;0];[8;3;1];[8;4;10]|]

module BipartiteMatching =
  @"cf. ../AtCoder/tessoku-book/A69/A69_fs_00_01.fsx"
  let bn1 N Ca =
    let caps =
      let caps = Array2D.create (2*N+2) (2*N+2) 0
      let a = 2*N
      let b = 2*N+1
      Ca |> array2D |> Array2D.iteri (fun i j c ->
        if c='#' then caps.[i,N+j] <- 1
        caps.[a,i] <- 1
        caps.[N+i,b] <- 1)
      caps
    let searchPath s g =
      let srch = System.Collections.Generic.Queue<int>() |> fun q -> q.Enqueue(s); q
      let bfr = Array.create (2*N+2) (-1) |> fun bfr -> bfr.[s] <- 0; bfr
      let rec frec b =
        if srch.Count = 0 then false
        else
          let i = srch.Dequeue()
          if i=g then true
          else
            for j in 0..(2*N+1) do if bfr.[j]<0 && 0<caps.[i,j] then srch.Enqueue(j); bfr.[j] <- i
            frec b
      (frec false, bfr)
    let updateFlow s g (bfr:int[]) =
      let rec frec c j =
        if j=s then c
        else let i = bfr.[j] in frec (min caps.[i,j] c) i
      let c = frec System.Int32.MaxValue g
      let rec grec j =
        if j<>s then let i = bfr.[j] in caps.[i,j] <- caps.[i,j]-c; caps.[j,i] <- caps.[j,i]+c; grec i
      grec g
      c
    let maxFlow s g =
      let rec frec acc =
        let (b, bfr) = searchPath s g
        if b then frec (acc + updateFlow s g bfr) else acc
      frec 0
    maxFlow (2*N) (2*N+1)

  @"cf. ../AtCoder/tessoku-book/A69/A69_fs_00_02.fsx"
  let bn2 N Ca =
    let es =
      let es = Array.init (2*N) (fun _ -> [])
      Ca |> array2D |> Array2D.iteri (fun i j c ->
        if c='#' then es.[i] <- (j+N)::es.[i]; es.[j+N] <- i::es.[j+N])
      es
    let matched = Array.create (2*N) (-1)
    let rec dfs v (used:bool[]) =
      used.[v] <- true
      let rec frec = function
        | [] -> false
        | u::t ->
          let w = matched.[u]
          if w<0 || not used.[w] && dfs w used then matched.[v] <- u; matched.[u] <- v; true
          else frec t
      frec es.[v]
    (0,[|0..2*N-1|]) ||> Array.fold (fun x v ->
      let used = Array.create (2*N) false
      if matched.[v]<0 && (dfs v used) then x+1 else x)


module BreadthFirstSearch =
  @"BFS: キューで再帰的に確認する"
  /// Imperative breadth-first search
  // Ex. ../AtCoder/tessoku-book/A63/A63_fs_00_01.fsx

  /// Functional depth-first search as a fold
  // Ex. ../AtCoder/tessoku-book/A63/A63_fs_00_02.fsx

module DepthFirstSearch =
  @"DFS: スタック(リスト)で再帰的に確認する"
  // Ex. ../AtCoder/tessoku-book/A62/A62_fs_00_01.fsx

  // https://gist.github.com/jdh30/512962cb29b96787c29964b2a7080db3
  /// Imperative depth-first search
  let dfs (V, E) =
    let visited = System.Collections.Generic.HashSet(HashIdentity.Structural)
    let stack = System.Collections.Generic.Stack[V]
    while stack.Count > 0 do
      let u = stack.Pop()
      if not(visited.Contains u) then
        for v in E u do stack.Push v
        visited.Add u |> ignore

  // https://gist.github.com/jdh30/512962cb29b96787c29964b2a7080db3
  /// Functional depth-first search as a fold
  let dfs f a (V, E) =
    let rec loop visited a = function
      | [] -> a
      | u::us ->
          if List.contains u visited
          then loop visited a us
          else loop (u::us) (f a u) (E u @ us)
    loop a V

  /// Ex: AtCoder ABC126 D, ../AtCoder/ABC126/D_fs_00_04.fsx
  let Aa = [|[(1,0)];[(2,1);(0,0)];[(1,1)]|]
  let rec dfs pi ci v Xa =
    Array.set Xa ci (v^^^1)
    Array.get Aa ci
    |> List.filter (fun (i,_) -> i <> pi)
    |> List.fold (fun acc (gci,w) -> dfs ci gci (v^^^w) acc) Xa
  Array.zeroCreate N |> dfs 0 0 1 |> should equal [|0;0;1|]

module Dijkstra =
  @"cf. AtCoder tessoku-book, A64 ../AtCoder/tessoku-book/A64/A64_fs_00_01.fsx
  到達経路がない場合`-1`を返す仕様."
  let N,M,Ma = 6,7,[|[];[(1,4,20L);(1,2,15L)];[(2,5,4L);(2,3,65L);(2,1,15L)];[(3,6,50L);(3,2,65L)];[(4,5,30L);(4,1,20L)];[(5,6,8L);(5,4,30L);(5,2,4L)];[(6,5,8L);(6,3,50L)]|]
  let dijkstra (Ma:(int*int*int64)list[]) =
    let n = Array.length Ma
    let Ca = Array.create n System.Int64.MaxValue |> fun c -> c.[1] <- 0L; c
    let q = System.Collections.Generic.SortedSet<int64*int>() |> fun q -> q.Add(0L,1) |> ignore; q
    while q.Count > 0 do
      let (c0,v0) = q.Min
      q.Remove((c0,v0)) |> ignore
      if v0<>(-1) then
        Ma.[v0] |> List.iter (fun (a,b,c) ->
          let (nv,nc) = (b,c+c0)
          if nc < Ca.[nv] then
            if Ca.[nv] <> System.Int64.MaxValue then q.Remove((Ca.[nv],nv)) |> ignore
            q.Add((nc,nv)) |> ignore
            Ca.[nv] <- nc)
    Ca |> Array.map (fun x -> if x=System.Int64.MaxValue then -1L else x)
  dijkstra Ma |> Array.tail |> should equal [|0L;15L;77L;20L;19L;27L|]

  @"cf. AtCoder ABC070_D, ../AtCoder/ABC070/D_fs_00_02.fsx
  `PriorityQueue`の代わりに`Set`を利用"
  let N,K,Ga = 5,1,[|[];[(3,1L);(2,1L)];[(4,1L);(1,1L)];[(5,1L);(1,1L)];[(2,1L)];[(3,1L)]|]
  let dijkstra N K (Ga: (int * int64) list []) =
    let Da = Array.create (N+1) System.Int64.MaxValue |> fun d -> d.[K] <- 0L; d
    let rec loop (Da:int64[]) q =
      if Set.isEmpty q then (Da,q)
      else
        let (c,v) = Set.minElement q
        let q0 = Set.remove (c,v) q
        if c <= Da.[v] then
          ((Da,q0), Ga.[v]) ||> List.fold (fun (Da,q) (bi,ci) ->
            let s = Da.[v]+ci
            if s < Da.[bi] then Da.[bi] <- s; (Da, Set.add (s,bi) q) else (Da,q))
        else (Da,q0)
        |> fun (Da,q) -> loop Da q
    loop Da (Set.singleton (0L,K)) |> fst |> Array.tail
  dijkstra N K Ga |> should equal [|0L;1L;1L;2L;2L|]

module FloydWarshall =
  @"Floyd-Warshall for int[][]"
  let fw1 iN jN kN (Ga:int[][]) =
    let Ra = array2D Ga
    for k in 0..kN-1 do for i in 0..iN-1 do for j in 0..jN-1 do Ra.[i,j] <- min Ra.[i,j] (Ra.[i,k]+Ra.[k,j])
    Ra

  @"Floyd-Warshall for int[,]"
  let fw2 iN jN kN (Ga:int[,]) =
    let Ra = Array2D.copy Ga
    for k in 0..kN-1 do for i in 0..iN-1 do for j in 0..jN-1 do Ra.[i,j] <- min Ra.[i,j] (Ra.[i,k]+Ra.[k,j])
    Ra

  @"Floyd-Warshall for Dictionary<int*int,int>"
  let fw3 iN jN kN (Ga:System.Collections.Generic.Dictionary<(int*int), int>) =
    for k in 0..kN-1 do for i in 0..iN-1 do for j in 0..jN-1 do Ga.[(i,j)] <- min Ga.[(i,j)] (Ga.[(i,k)]+Ga.[(k,j)])
    Ga

module FordFulkerson =
  @"Maximum Flow
  破壞的な実装
  cf. ../AtCoder/tessoku-book/A68/A68_fs_00_02.fsx"
  let ff1 N Ia =
    let caps =
      (Array2D.create N N 0, Ia)
      ||> Array.fold (fun caps (a,b,c) -> caps.[a-1,b-1] <- c; caps)
    let searchPath s g =
      let srch = System.Collections.Generic.Queue<int>() |> fun q -> q.Enqueue(s); q
      let bfr = Array.create N (-1) |> fun bfr -> bfr.[s] <- 0; bfr
      let rec frec b =
        if srch.Count = 0 then false
        else
          let i = srch.Dequeue()
          if i=g then true
          else
            for j in 0..(N-1) do if bfr.[j]<0 && 0<caps.[i,j] then srch.Enqueue(j); bfr.[j] <- i
            frec b
      (frec false, bfr)
    let updateFlow s g (bfr:int[]) =
      let rec frec c j =
        if j=s then c
        else let i = bfr.[j] in frec (min caps.[i,j] c) i
      let c = frec System.Int32.MaxValue g
      let rec grec j =
        if j<>s then let i = bfr.[j] in caps.[i,j] <- caps.[i,j]-c; caps.[j,i] <- caps.[j,i]+c; grec i
      grec g
      c
    let maxFlow s g =
      let rec frec acc =
        let (b, bfr) = searchPath s g
        if b then frec (acc + updateFlow s g bfr) else acc
      frec 0
    maxFlow 0 (N-1)

@"UnionFind -> ../DataStructures/UnionFind.fsx"
