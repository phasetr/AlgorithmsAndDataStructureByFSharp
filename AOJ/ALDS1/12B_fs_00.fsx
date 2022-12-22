#r "nuget: FsUnit"
open FsUnit

let solve N (Aa: int list[]) =
  let maxInt = System.Int32.MaxValue
  let dijkstra N s (g: int[,]) =
    let d = Array.create N maxInt
    d.[s] <- 0
    let av = Array.create N true
    let rec minCost i r =
      if i=N then r
      else if av.[i] then
        match r with
          | None -> minCost (i+1) (Some i)
          | Some j -> if d.[i] < d.[j] then minCost (i+1) (Some i) else minCost (i+1) r
      else minCost (i+1) r
    let rec loop () =
      match minCost 0 None with
        | None -> d
        | Some u ->
          av.[u] <- false
          g.[u,0..]
          |> Array.iteri (fun v w -> if w >= 0 && av.[v] then if d.[u] + w < d.[v] then d.[v] <- d.[u] + w)
          loop ()
    loop ()
  (Array2D.create N N -1, Aa)
  ||> Array.fold
    (fun g a ->
     let u,k = a.[0],a.[1]
     let rec read (g: int[,]) l =
       match l with
         | [] -> g
         | v::c::tail -> Array2D.set g u v c; read g tail
         | _ -> failwith "not come here"
     read g a.[2..])
  |> dijkstra N 0 |> Array.mapi (fun i x -> [|i;x|])

let N = stdin.ReadLine() |> int
let Aa = [| for i in 1..N do (stdin.ReadLine().Split() |> Array.map int |> Array.toList) |]
solve Xa |> Array.map string |> String.concat "\n" |> stdout.WriteLine
solve N Aa |> stdout.WriteLine

let N,Aa = 5,[|[0;3;2;3;3;1;1;2];[1;2;0;2;3;4];[2;3;0;3;3;1;4;1];[3;4;2;1;0;1;1;4;4;3];[4;2;2;1;3;3]|]
solve N Aa |> should equal [|[|0;0|];[|1;2|];[|2;2|];[|3;1|];[|4;3|]|]
