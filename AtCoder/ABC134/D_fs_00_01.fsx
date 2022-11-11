#r "nuget: FsUnit"
open FsUnit

let N,Aa = 3,[|1;0;0|]
let N,Aa = 5,[|0;0;0;0;0|]
let solve N (Aa:int[]) =
  (Array.create N false, [|0..N-1|])
  ||> Array.fold (fun acc i0 ->
    let i = N-i0-1
    let c = (0,[|1..(N/(i+1))|]) ||> Array.fold (fun c j -> if acc.[(i+1)*j-1] then c+1 else c)
    Array.set acc i (if c%2 = Aa.[i] then acc.[i] else true)
    acc)
  |> Array.mapi (fun i x -> if x then i+1 else -1)
  |> Array.filter (fun x -> x <> -1)
  |> fun a -> [|string a.Length; a |> Array.map string |> String.concat " "|]

let solve N (Aa:int[]) =
  (Array.create N false, [|N-1..(-1)..0|])
  ||> Array.fold (fun acc i ->
    let c = (0,[|1..(N/(i+1))|]) ||> Array.fold (fun c j -> if acc.[(i+1)*j-1] then c+1 else c)
    Array.set acc i (if c%2 = Aa.[i] then acc.[i] else true)
    acc)
  |> Array.mapi (fun i x -> if x then i+1 else -1)
  |> Array.filter (fun x -> x <> -1)
  |> fun a -> [|string a.Length; a |> Array.map string |> String.concat " "|]

let N = stdin.ReadLine() |> int
let Aa = stdin.ReadLine().Split() |> Array.map int
solve N Aa |> String.concat "\n" |> stdout.WriteLine

solve 3 [|1;0;0|] |> should equal [|"1";"1"|]
solve 5 [|0;0;0;0;0|] |> should equal [|"0";""|]
