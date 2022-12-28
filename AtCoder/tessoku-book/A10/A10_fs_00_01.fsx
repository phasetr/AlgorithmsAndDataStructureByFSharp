#r "nuget: FsUnit"
open FsUnit

(*
let N,Aa,D,Ia = 7,[|1;2;5;5;2;3;1|],2,[|(3,5);(4,6)|]
*)
let solveTLE N (Aa:int[]) D Ia =
  let Na =
    [|0..N-1|]
    |> Array.map (fun i -> [|i..N-1|] |> Array.map (fun j ->
      if Array.isEmpty Aa.[i..j] then 0 else Array.max Aa.[i..j]))
  Ia |> Array.map (fun (l,r) -> max Na.[0].[l-2] Na.[r].[N-r-1])

let solve N Aa D Ia =
  let La = Array.scan max 0 Aa
  let Ra = Array.scanBack max Aa 0
  Ia |> Array.map (fun (l,r) -> max La.[l-1] Ra.[r])

let N = stdin.ReadLine() |> int
let Aa = stdin.ReadLine().Split() |> Array.map int
let D = stdin.ReadLine() |> int
let Ia = Array.init D (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1])
solve N Aa D Ia |> Array.iter stdout.WriteLine

solve 7 [|1;2;5;5;2;3;1|] 2 [|(3,5);(4,6)|] |> should equal [|3;5|]

@"記事用コード"
Array.scan max 0 Aa |> should equal [|0; 1; 2; 5; 5; 5; 5; 5|]
Array.scanBack max Aa 0 |> should equal [|5; 5; 5; 5; 3; 3; 1; 0|]
