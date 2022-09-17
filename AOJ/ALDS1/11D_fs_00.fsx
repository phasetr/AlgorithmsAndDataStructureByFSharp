#r "nuget: FsUnit"
open FsUnit

let solve N M (Aa: int[][]) Q (Qa: int[][]) =
  let dfs (vs: int list[]) n =
    let mutable d = Array.create n (-1) in
    let rec doit i j =
      d.[i] <- j;
      List.iter (fun v -> if d.[v] = (-1) then doit v j) vs.[i]
    Array.iteri (fun i e -> if e = (-1) then doit i i) d
    d
  let mutable g = Array.create N ([]: int list)
  Aa |> Array.iter (fun a -> g.[a.[0]] <- a.[1]::g.[a.[0]])
  let v = dfs g N
  Qa |> Array.map (fun [|s;t|] -> if v.[s]=v.[t] then "yes" else "no")

let N,M = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Aa = [| for i in 1..M do (stdin.ReadLine().Split() |> Array.map int) |]
let Q =  stdin.ReadLine() |> int
let Qa = [| for i in 1..Q do (stdin.ReadLine().Split() |> Array.map int) |]
solve N M Aa Q Qa |> String.concat "\n" |> stdout.WriteLine

let N,M,Aa,Q,Qa = 10,9,[|[|0;1|];[|0;2|];[|3;4|];[|5;7|];[|5;6|];[|6;7|];[|6;8|];[|7;8|];[|8;9|]|],3,[|[|0;1|];[|5;9|];[|1;3|]|]
solve N M Aa Q Qa |> should equal [|"yes";"yes";"no"|]
