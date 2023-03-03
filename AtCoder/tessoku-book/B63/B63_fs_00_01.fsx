#r "nuget: FsUnit"
open FsUnit

(*
let R,C,sy,sx,gy,gx,Ca = 7,8,2,2,4,5,[|"########";"#......#";"#.######";"#..#...#";"#..##..#";"##.....#";"########"|]
let R,C,sy,sx,gy,gx,Ca = 5,8,2,2,2,4,[|"########";"#.#....#";"#.###..#";"#......#";"########"|]
*)
let solve R C sy sx gy gx (Ca:string[]) =
  let start,goal = sy*C+sx,gy*C+gx
  let Ga =
    let Ga = Array.create (R*C) []
    for i in 1..R do
      for j in 1..C-1 do
        let idx1,idx2 = i*C+j,i*C+(j+1)
        if Ca.[i-1].[j-1]='.' && Ca.[i-1].[j]='.' then Ga.[idx1] <- idx2::Ga.[idx1]; Ga.[idx2] <- idx1::Ga.[idx2]
    for i in 1..R-1 do
      for j in 1..C do
        let idx1,idx2 = i*C+j,(i+1)*C+j
        if Ca.[i-1].[j-1]='.' && Ca.[i].[j-1]='.' then Ga.[idx1] <- idx2::Ga.[idx1]; Ga.[idx2] <- idx1::Ga.[idx2]
    Ga
  let dist = Array.create (R*C) -1 |> fun d -> d.[start] <- 0; d
  let Q = System.Collections.Generic.Queue<int>() |> fun q -> q.Enqueue(start); q
  while Q.Count<>0 do
    let pos = Q.Dequeue()
    for idx in Ga.[pos] do
      if dist.[idx]=(-1) then dist.[idx] <- dist.[pos]+1; Q.Enqueue(idx)
  dist.[goal]
let R,C = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let sy,sx = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let gy,gx = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Ca = Array.init R (fun _ -> stdin.ReadLine())
solve R C sy sx gy gx Ca |> stdout.WriteLine

solve 7 8 2 2 4 5 [|"########";"#......#";"#.######";"#..#...#";"#..##..#";"##.....#";"########"|] |> should equal 11
solve 5 8 2 2 2 4 [|"########";"#.#....#";"#.###..#";"#......#";"########"|] |> should equal 10
