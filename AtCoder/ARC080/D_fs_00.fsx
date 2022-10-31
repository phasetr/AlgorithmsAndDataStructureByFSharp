#r "nuget: FsUnit"
open FsUnit

let H,W,N,Aa = 2,2,3,[|2;1;1|]
let H,W,N,Aa = 3,5,5,[|1;2;3;4;5|]
@"うねうね曲がりながら順に指定された分だけ数を詰めていけばよい.
はじめにXaとして詰めるべき数の配列を作り,
うねうね曲がるための添字の配列を作って二次元配列に詰めて処理する."
let solve H W N Aa =
  let Xa = Aa |> Array.mapi (fun i a -> Array.create a (i+1)) |> Array.concat
  [|0..H-1|] |> Array.map (fun i -> (if i%2=1 then [|0..W-1|] else [|W-1..(-1)..0|]) |> Array.map (fun j -> (i,j)))
  |> Array.concat
  |> Array.zip Xa
  |> Array.fold (fun a (x, (i,j)) -> Array2D.set a i j x; a) (Array2D.zeroCreate H W)
  |> fun x -> [|0..H-1|] |> Array.map (fun i -> x.[i,*] |> Array.map string |> String.concat " ")
  |> String.concat "\n"

let H,W = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let N = stdin.ReadLine() |> int
let Aa = stdin.ReadLine().Split() |> Array.map int
solve H W N Aa |> stdout.WriteLine

solve 2 2 3 [|2;1;1|]
solve 3 5 5 [|1;2;3;4;5|]
