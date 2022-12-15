#r "nuget: FsUnit"
open FsUnit

(*
let H,W,Aa = 3,3,[|"...";".#.";"..."|]
let H,W,Aa = 6,6,[|"..#..#";"......";"#..#..";"......";".#....";"....#."|]
*)
let solve H W Aa =
  let isWhite x y (Da:int[,]) = 0<=y && y<H && 0<=x && x<W && Da.[y,x]=(-1)
  let Ma = [|(-1,0);(0,-1);(1,0);(0,1)|]
  let q = System.Collections.Generic.Queue<int*int>()
  let Da = Array2D.init H W (fun _ _ -> -1)
  Aa |> array2D |> Array2D.iteri (fun i j c -> if c='#' then Da.[i,j] <- 0; q.Enqueue(i,j))

  let mutable ans = 0
  while q.Count <> 0 do
    let y0,x0 = q.Dequeue()
    Ma |> Array.iter (fun (dx,dy) ->
      let x,y = x0+dx, y0+dy
      if isWhite x y Da then ans <- Da.[y0,x0]+1; Da.[y,x] <- ans; q.Enqueue(y,x))
  ans

let H,W = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Aa = Array.init H (fun _ -> stdin.ReadLine())
solve H W Aa |> stdout.WriteLine

solve 3 3 [|"...";".#.";"..."|] |> should equal 2
solve 6 6 [|"..#..#";"......";"#..#..";"......";".#....";"....#."|] |> should equal 3
