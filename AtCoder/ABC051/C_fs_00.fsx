#r "nuget: FsUnit"
open FsUnit

"""
行きが決まれば帰りは経路を反転させればよい.
一回目は文字通りの最短経路で,
二回目は迂回路を取る.
一度下に降りてから右に行き, 一つ余計に右に進んでからy座標を合わせて左に進む.
"""
let sx,sy,tx,ty=0,0,1,2
let solve sx sy tx ty =
  let rep = List.replicate
  let nx = tx-sx
  let ny = ty-sy
  let one = rep nx "R" @ rep ny "U" @ rep nx "L" @ rep ny "D"
  let two = ["D"] @ rep (nx+1) "R" @ rep (ny+1) "U" @ ["L"]
            @ ["U"] @ rep (nx+1) "L" @ rep (ny+1) "D" @ ["R"]
  one @ two |> System.String.Concat

let sx,sy,tx,ty = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1],x.[2],x.[3])
solve sx sy tx ty |> stdout.WriteLine

solve 0 0 1 2
solve -2 -2 1 1
