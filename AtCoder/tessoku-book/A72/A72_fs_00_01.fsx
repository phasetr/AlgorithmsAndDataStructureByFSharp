#r "nuget: FsUnit"
open FsUnit

(*
let H,W,K,Ca = 4,10,3,[|"##...#.##.";".#....#...";"##.####..#";"#..######."|]
*)
let solve H W K Ca =
  let wr = Array.create H 0
  let wc = Array.create W 0
  let mutable res = 0
  Ca |> Array.iteri (fun i s -> s |> Seq.iteri (fun j c -> if c='.' then wr.[i] <- wr.[i]+1; wc.[j] <- wc.[j]+1 else res <- res+1))
  let wr0 = wr |> Array.sortDescending
  let wc0 = wc |> Array.sortDescending
  ((0,0), [|0..K-1|]) ||> Array.fold (fun (cr,cc) i -> (cr+wr0.[i], cc+wc0.[i]))
  |> fun (cr,cc) -> res + max cr cc

let solve H W K Ca =
  (Array.create H 0, Array.create W 0)
  |> fun (wr,wc) ->
    let mutable res = 0
    Ca |> Array.iteri (fun i s -> s |> Seq.iteri (fun j c -> if c='.' then wr.[i] <- wr.[i]+1; wc.[j] <- wc.[j]+1 else res <- res+1))
    (wr,wc,res)
  |> fun (wr0,wc0,res) ->
    let wr = wr0 |> Array.sortDescending
    let wc = wc0 |> Array.sortDescending
    ((0,0), [|0..K-1|]) ||> Array.fold (fun (cr,cc) i -> (cr+wr.[i], cc+wc.[i]))
    |> fun (cr,cc) -> res + max cr cc

let H,W,K = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1],x.[2])
let Ca = Array.init H (fun _ -> stdin.ReadLine())
solve H W K Ca |> stdout.WriteLine

solve 4 10 3 [|"##...#.##.";".#....#...";"##.####..#";"#..######."|] |> should equal 37
// 10_random_00
solve 5 20 2 [|"...######.#...#.##.#";"##.#.#.###.#...##.#.";"##..##...#.#..#.##..";".##.#..#..###.####.#";"##.#########..##.###"|] |> should equal 79
