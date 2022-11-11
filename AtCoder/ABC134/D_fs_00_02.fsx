#r "nuget: FsUnit"
open FsUnit

let N,Aa = 3,[|1;0;0|]
let N,Aa = 5,[|0;0;0;0;0|]
// D_fs_00_01.fsxより遅い模様: chooseが重い? 理由をきちんと知りたい.
let solve N (Aa:int[]) =
  (Array.init N (fun i -> (i+1,false)), [|0..N-1|])
  ||> Array.fold (fun acc i0 ->
    let i = N-i0-1
    let c = (0,[|1..(N/(i+1))|]) ||> Array.fold (fun c j -> if snd acc.[(i+1)*j-1] then c+1 else c)
    Array.set acc i (fst acc.[i], (if c%2 = Aa.[i] then snd acc.[i] else true))
    acc)
  |> Array.choose (fun (i,b) -> if b then Some i else None)
  |> fun a -> [|string a.Length; a |> Array.map string |> String.concat " "|]

let N = stdin.ReadLine() |> int
let Aa = stdin.ReadLine().Split() |> Array.map int
solve N Aa |> String.concat "\n" |> stdout.WriteLine

solve 3 [|1;0;0|] |> should equal [|"1";"1"|]
solve 5 [|0;0;0;0;0|] |> should equal [|"0";""|]
