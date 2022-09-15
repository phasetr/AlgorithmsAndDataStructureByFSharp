#r "nuget: FsUnit"
open FsUnit

let solve N (Aa: int list[]) =
  let mutable d = Array.create N 0
  let mutable f = Array.create N 0
  let mutable time = 1
  let g = Aa |> Array.map (fun a -> a.[0] :: a.[2..])
  let rec dudu = function
    | [] -> ()
    | hd :: tl when d.[hd-1] = 0 -> timeCount (hd-1); dudu tl
    | _ :: tl -> dudu tl
  and timeCount i =
    d.[i] <- time; time <- time+1
    dudu g.[i]
    f.[i] <- time; time <- time+1
  and frec i = if i < N then (if d.[i] = 0 then timeCount i; frec (i+1))
  frec 0
  [|0..N-1|] |> Array.map (fun i -> $"{i+1} {d.[i]} {f.[i]}")

let N = stdin.ReadLine() |> int
let Aa = [| for i in 1..N do (stdin.ReadLine().Split() |> Array.map int |> Array.toList) |]
solve N Aa |> Array.iter stdout.WriteLine

let N,Aa = 4,[|[1;1;2];[2;1;4];[3;0];[4;1;3]|]
solve N Aa |> should equal [|"1 1 8"; "2 2 7"; "3 4 5"; "4 3 6"|]
let N,Aa = 6,[|[1;2;2;3];[2;2;3;4];[3;1;5];[4;1;6];[5;1;6];[6;0]|]
solve N Aa |> should equal [|"1 1 12"; "2 2 11"; "3 3 8"; "4 9 10"; "5 4 7"; "6 5 6"|]
