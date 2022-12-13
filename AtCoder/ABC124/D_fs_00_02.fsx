#r "nuget: FsUnit"
open FsUnit

(*
let N,K,S = 5,1,"00010"
let N,K,S = 14,2,"11101010110011"
let N,K,S = 1,1,"1"
*)
let solve N K (S:string) =
  let Ia =
    ([0], [|0..N-2|])
    ||> Array.fold (fun acc i -> if S.[i]=S.[i+1] then acc else (i+1)::acc)
    |> fun xs -> N::xs
    |> List.rev |> List.toArray
  let l0 = Array.length Ia - 1
  (0, [|0..l0-1|])
  ||> Array.fold (fun acc i ->
    let j = min (i+2*K + (int S.[Ia.[i]] - int '0')) l0
    max acc (Ia.[j]-Ia.[i]))

let N,K = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let S = stdin.ReadLine()
solve N K S |> stdout.WriteLine

solve 5 1 "00010" |> should equal 4
solve 14 2 "11101010110011" |> should equal 8
solve 1 1 "1" |> should equal 1
