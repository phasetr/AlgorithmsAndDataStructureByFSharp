#r "nuget: FsUnit"
open FsUnit

let solve (aa:int[][]) =
  let mutable xa = Array3D.create 4 3 10 0
  for a in aa do xa.[a.[0]-1,a.[1]-1,a.[2]-1] <- a.[3] done
  for i in [0..3] do
    for j in [0..2] do
      xa.[i,j,*] |> Array.map string |> String.concat " " |> printf " %s\n"
    done
    if i<3 then printfn "####################" else ()
  done

let n = stdin.ReadLine() |> int
let aa = [| for i in 1..n do (stdin.ReadLine().Split |> Array.map int) |]
solve Xa |> String.concat "\n" |> stdout.WriteLine

let aa = [|[|1;1;3;8|];[|3;2;2;7|];[|4;3;8;1|]|]
solve aa
