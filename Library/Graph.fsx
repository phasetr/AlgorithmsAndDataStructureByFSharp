#r "nuget: FsUnit"
open FsUnit

module AdjacencyList =
  @"ResizeArrayで生成, cf. https://atcoder.jp/contests/abc157/tasks/abc157_d"
  let toAdjacencyList N Xa =
    let Ga = Array.create N (ResizeArray<int>())
    Xa |> Array.iter (fun (a,b) -> g.[a-1].Add (b-1); g.[b-1].Add (a-1))
    g |> Array.map (fun a -> a.ToArray())

module DepthFirstSearch =
  @"DFS"
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

@"UnionFind -> ../DataStructures/UnionFind.fsx"
