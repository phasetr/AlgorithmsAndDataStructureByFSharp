#r "nuget: FsUnit"
open FsUnit

let N,M,Aa,Ba = 3,2,[|"#.#";".#.";"#.#"|],[|"#.";".#"|]
let solve N M (Aa:string[]) (Ba:string[]) =
  let L = N-M
  let Ca = [| for i in 0..M-1 do for j in 0..M-1 -> i,j |]
  let a = Ba |> Seq.concat |> Seq.toArray |> System.String
  [| for i in 0..L do for j in 0..L -> i,j |]
  |> Array.map (fun (i,j) -> Aa.[i..i+M-1] |> Seq.collect (fun s -> s.[j..j+M-1]) |> Array.ofSeq|> System.String |> fun s -> s=a)
  |> fun b -> if Array.exists id b then "Yes" else "No"

let N,M = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Aa = [| for i in 1..N do stdin.ReadLine() |]
let Ba = [| for i in 1..M do stdin.ReadLine() |]
solve N M Aa Ba |> stdout.WriteLine

solve 3 2 [|"#.#";".#.";"#.#"|] [|"#.";".#"|] |> should equal "Yes"
solve 4 1 [|"....";"....";"....";"...."|] [|"#"|] |> should equal "No"
solve 1 1 [|"."|] [|"."|] |> should equal "Yes"
