#r "nuget: FsUnit"
open FsUnit
open System.Collections.Generic

let solve N (Aa: int list[]) =
  let g = Aa |> Array.map (fun a -> a.[0] :: a.[2..])
  let mutable d = Array.create N (-1)
  let mutable q = Queue<int>()
  let rec duduwa i = function
    | [] -> ()
    | hd :: tl when d.[hd-1] = (-1) -> (d.[hd-1] <- d.[i]+1; q.Enqueue (hd-1); duduwa i tl)
    | _ :: tl -> duduwa i tl
  and doit () =
    if (q.Count <> 0) then
      let i = q.Dequeue()
      duduwa i g.[i]
      doit ()
  q.Enqueue 0
  d.[0] <- 0
  doit ()
  [|0..N-1|] |> Array.map (fun i -> $"{i+1} {d.[i]}")

  let rec print i =
    if i < n then (Printf.printf "%d %d\n" (i + 1) d.(i); print (i + 1))
  in
  print 0;

let N = stdin.ReadLine() |> int
let Aa = [| for i in 1..N do (stdin.ReadLine().Split() |> Array.map int |> Array.toList) |]
solve N Aa |> Array.iter stdout.WriteLine

let N,Aa = 4,[|[1;2;2;4];[2;1;4];[3;0];[4;1;3]|]
solve N Aa |> should equal [|"1 0";"2 1";"3 2";"4 1"|]
