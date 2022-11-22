#r "nuget: FsUnit"
open FsUnit

let H,W,Sa = 3,3,[|"..#";"#..";"..."|]
let solve H W Sa =
  let Ma,wNum =
    let Ma = Array2D.create (H+2) (W+2) '#'
    let mutable wNum = 0
    Sa |> array2D |> Array2D.iteri (fun i j c -> Array2D.set Ma (i+1) (j+1) c; if c='.' then wNum<-wNum+1)
    Ma,wNum
  let rec bfs h w g = function
    | [] -> -1
    | ((i,j),l)::q ->
      if (i,j)=(h,w) then l
      else if Array2D.get g i j='#' then bfs h w g q
      else
        let nbhs = [(i-1,j);(i+1,j);(i,j-1);(i,j+1)] |> List.map (fun t -> (t,l+1))
        Array2D.set g i j '#'
        bfs h w g (q@nbhs)
  let l = bfs H W Ma [((1,1),1)] in if l=(-1) then -1 else wNum-l

let H,W = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Sa = Array.init H (fun _ -> stdin.ReadLine())
solve H W Sa |> stdout.WriteLine

solve 3 3 [|"..#";"#..";"..."|] |> should equal 2
solve 10 37 [|".....................................";"...#...####...####..###...###...###..";"..#.#..#...#.##....#...#.#...#.#...#.";"..#.#..#...#.#.....#...#.#...#.#...#.";".#...#.#..##.#.....#...#.#.###.#.###.";".#####.####..#.....#...#..##....##...";".#...#.#...#.#.....#...#.#...#.#...#.";".#...#.#...#.##....#...#.#...#.#...#.";".#...#.####...####..###...###...###..";"....................................."|] |> should equal 209
