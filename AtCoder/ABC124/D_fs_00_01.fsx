#r "nuget: FsUnit"
open FsUnit

(*
let N,K,S = 5,1,"00010"
let N,K,S = 14,2,"11101010110011"
let N,K,S = 1,1,"1"
*)
let solve N K (S:string) =
  let rec group acc i c m =
    if N<=i then if c = '1' then m::acc else 0::m::acc |> List.rev
    else if S.[i] <> c then group (m::acc) (i+1) S.[i] 1
    else group acc (i+1) S.[i] (m+1)
  let Ba = group [] 0 '1' 0 |> List.toArray
  let m = Array.length Ba
  let Xa = Ba |> Array.scan (+) Ba.[0]

  let rec frec i ans =
    if m<i then ans
    else let r = min m (i+2*K+1) in frec (i+2) (max ans (Xa.[r]-Xa[i]))
  frec 0 0

let N,K = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let S = stdin.ReadLine()
solve N K S |> stdout.WriteLine

solve 5 1 "00010" |> should equal 4
solve 14 2 "11101010110011" |> should equal 8
solve 1 1 "1" |> should equal 1
