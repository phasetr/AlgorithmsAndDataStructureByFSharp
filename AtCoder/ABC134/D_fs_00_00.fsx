#r "nuget: FsUnit"
open FsUnit

let N,Aa = 3,[|1;0;0|]
let N,Aa = 5,[|0;0;0;0;0|]
@"TLEしたコード"
let solve N (Aa:int[]) =
  let Sa =
    ([|1..N|] |> Array.map (fun i -> (i,0)), [|N..(-1)..1|])
    ||> Array.fold (fun acc i ->
      let s = (0, acc) ||> Array.fold (fun s (j,a) -> if j%1=0 then s+a else s)
      Array.set acc (i-1) (i-1, if s%2=Aa.[i-1] then 0 else 1)
      acc)
  let m = Sa |> Array.sumBy snd
  let Ba = Sa |> Array.choose (fun (i,a) -> if a=1 then Some (sprintf "%d" (i+1)) else None) |> String.concat " "
  [|string m; Ba|]

let N = stdin.ReadLine() |> int
let Aa = stdin.ReadLine().Split() |> Array.map int
solve N Aa |> String.concat "\n" |> stdout.WriteLine

solve 3 [|1;0;0|] |> should equal [|"1";"1"|]
solve 5 [|0;0;0;0;0|] |> should equal [|"0";""|]
