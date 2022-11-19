#r "nuget: FsUnit"
open FsUnit

// https://gist.github.com/jdh30/512962cb29b96787c29964b2a7080db3
module Sample1 =
  open System.Collections.Generic

  /// Imperative depth-first search
  let dfs (V, E) =
    let visited = HashSet(HashIdentity.Structural)
    let stack = Stack[V]
    while stack.Count > 0 do
      let u = stack.Pop()
      if not(visited.Contains u) then
        for v in E u do
          stack.Push v
        visited.Add u
        |> ignore

  /// Functional depth-first search as a fold
  let dfs f a (V, E) =
    let rec loop visited a = function
      | [] -> a
      | u::us ->
          if List.contains u visited then loop visited a us else
            loop (u::us) (f a u) (E u @ us)
    loop a V
