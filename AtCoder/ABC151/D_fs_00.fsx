#r "nuget: FsUnit"
open FsUnit

let H,W,Sa = 3,3,[|"...";"...";"..."|]
let H,W,Sa = 3,5,[|"...#.";".#.#.";".#..."|]

// 外周を通行不能設定で追加する
open System.Collections.Generic
let solve H W Sa =
  let toMap Sa =
    let d = Dictionary<int*int, char>()
    Sa |> array2D |> Array2D.iteri (fun i j c -> d.Add((i+1,j+1),c))
    [|0..H+1|] |> Array.iter (fun i -> d.Add((i,0),'#'); d.Add((i,W+1),'#'))
    [|1..W|] |> Array.iter (fun j -> d.Add((0,j),'#'); d.Add((H+1,j),'#'))
    d
  let maze = Sa |> toMap |> array2D
  // 辞書を書き換えてしまうので不適
  let rec bfs l (maze:Dictionary<int*int,char>) = function
    | [] -> l
    | (((i,j),d)) :: q ->
      if maze.[(i,j)]='#' then bfs l maze q
      else
        let r =
          [(i-1,j);(i+1,j);(i,j-1);(i,j+1)]
          |> List.choose (fun (i,j) -> if maze.[(i,j)]='.' then (Some((i,j),d+1)) else None)
        printfn "%A" (maze.[(i,j)])
        maze.[(i,j)] <- '#'
        printfn "%A" (maze.[(i,j)])
        bfs d maze (q@r)
  let pLen i j maze = bfs 0 maze [((i,j), 0)]
  pLen 3 1 maze
  [| for i in 1..H do for j in 1..W do (i,j) |] |> Array.map (fun (i,j) -> bfs 0 maze [((i,j),0)])

@"こちらも配列へのsetで書き換えが起こってしまうため`Array2D.copy`を挟んでいる. どうにかならないか."
let solve H W Sa =
  let toMap Sa =
    let Ta = Array2D.create (H+2) (W+2) 'a'
    Sa |> array2D |> Array2D.iteri (fun i j c -> Array2D.set Ta (i+1) (j+1) c)
    [|0..H+1|] |> Array.iter (fun i -> Array2D.set Ta i 0 '#'; Array2D.set Ta i (W+1) '#')
    [|1..W|] |> Array.iter (fun j -> Array2D.set Ta 0 j '#'; Array2D.set Ta (H+1) j '#')
    Ta
  let rec bfs l (maze:char[,]) = function
    | [] -> l
    | (((i,j),d)) :: q ->
      if maze.[i,j]='#' then bfs l maze q
      else
        let r =
          [(i-1,j);(i+1,j);(i,j-1);(i,j+1)]
          |> List.choose (fun (i,j) -> if maze.[i,j]='.' then (Some((i,j),d+1)) else None)
        Array2D.set maze i j '#'
        bfs d maze (q@r)
  let pLen i j maze = Array2D.copy maze |> fun a -> bfs 0 a [((i,j), 0)]
  let maze = Sa |> toMap
  [| for i in 1..H do for j in 1..W do (i,j) |] |> Array.map (fun (i,j) -> pLen i j maze) |> Array.max

let H,W = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Sa = [| for i in 1..H do (stdin.ReadLine()) |]
solve H W Sa |> stdout.WriteLine

solve 3 3 [|"...";"...";"..."|] |> should equal 4
solve 3 5 [|"...#.";".#.#.";".#..."|] |> should equal 10
