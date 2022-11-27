#r "nuget: FsUnit"
open FsUnit

// let N,K,Da = 1000,8,[|1;3;4;5;6;7;8;9|]
// let N,K,Da = 9999,1,[|0|]
let solve N K Da =
  let Aa = Array.except Da [|0..9|] |> Array.map (string >> char)
  let rec check n = if (n |> string |> Seq.forall (fun c -> Array.contains c Aa)) then n else check (n+1)
  check N

let N,K = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Da = stdin.ReadLine().Split() |> Array.map int
solve N K Da |> stdout.WriteLine

solve 1000 8 [|1;3;4;5;6;7;8;9|] |> should equal 2000
solve 9999 1 [|0|] |> should equal 9999
