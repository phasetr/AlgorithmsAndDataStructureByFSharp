#r "nuget: FsUnit"
open FsUnit

(*
let N,S = 6,"abcbac"
*)
let solveTLE N (S:string) =
  [|1..N-1|] |> Array.map (fun i ->
    [|0..N-1-i|]
    |> Array.choose (fun l -> if [|0..l|] |> Array.forall (fun k -> S.[k]<>S.[k+i]) then Some(l+1) else None)
    |> fun xa -> if xa.Length=0 then 0 else Array.last xa)

let solve N (S:string) =
  let rec frec i k =
    if k+i=N then k
    elif S.[k]<>S.[k+i] then frec i (k+1)
    else k
  [|1..N-1|] |> Array.map (fun i -> frec i 0)

let N = stdin.ReadLine() |> int
let S = stdin.ReadLine()
solve N S |> Array.iter stdout.WriteLine

solve 6 "abcbac" |> should equal [|5;1;2;0;1|]
