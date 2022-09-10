#r "nuget: FsUnit"
open FsUnit

let solve N Ha =
  let w: string -> unit = stdout.Write
  let Xa = [|0..N|] |> Array.map (fun i -> if i=0 then 0 else Ha.[i-1])
  [|1..N|]
  |> Array.iter
    (fun i ->
     w $"node {i}: key = {Xa.[i]}, "
     let p=i/2 in if p<>0 then w $"parent key = {Xa.[p]}, "
     let l=2*i in if l<=N then w $"left key = {Xa.[l]}, "
     let r=2*i+1 in if r<=N then w $"right key = {Xa.[r]}"
     stdout.Write "\n")

let N = stdin.ReadLine() |> int
let Ha = stdin.ReadLine().Split() |> Array.map int
solve N Ha

let N,Ha = 5,[|7;8;1;2;3|]
solve N Ha
"""
node 1: key = 7, left key = 8, right key = 1,
node 2: key = 8, parent key = 7, left key = 2, right key = 3,
node 3: key = 1, parent key = 7,
node 4: key = 2, parent key = 8,
node 5: key = 3, parent key = 8,
"""
