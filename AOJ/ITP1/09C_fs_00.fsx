#r "nuget: FsUnit"
open FsUnit

let solve Aa = ((0,0), Aa) ||> Array.fold (fun (t,h) (ct,ch) -> if ct<ch then (t,h+3) else if ct=ch then (t+1,h+1) else (t+3,h))

let N = stdin.ReadLine() |> int
let Aa = [| for i in 1..N do (stdin.ReadLine().Split() |> fun x -> x.[0],x.[1]) |]
solve Aa |> stdout.WriteLine

let Aa = [|("cat","dog");("fish","fish");("lion","tiger")|]
solve Aa |> should equal (1,7)
