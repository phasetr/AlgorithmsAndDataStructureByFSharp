#r "nuget: FsUnit"
open FsUnit

(*
let N,Q,S,Ia = 7,3,"abcbabc",[|(1,3,5,7);(1,5,2,6);(1,2,6,7)|]
*)
let solve N Q S (Ia:(int*int*int*int)[]) =
  let cToInt64 (c:char) = int64 c - 48L
  let p = 31L
  let MOD = 1_000_000_007L
  let (.*) x y = (x*y)%MOD
  let Sa = S |> Seq.toArray
  let (pow,hash) =
    ((Array.create (N+1) 1L,Array.create (N+1) 1L), [|1..N|])
    ||> Array.fold (fun (pow,hash) i ->
      pow.[i] <- pow.[i-1].*p
      hash.[i] <- (hash.[i-1] + pow.[i-1] * cToInt64 Sa.[i-1])%MOD
      (pow,hash))
  Ia |> Array.map (fun (a,b,c,d) ->
    let ba = ((hash.[b]-hash.[a-1]+MOD)%MOD).*pow.[N-a]
    let dc = ((hash.[d]-hash.[c-1]+MOD)%MOD).*pow.[N-c]
    if ba=dc then "Yes" else "No")

let N,Q = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let S = stdin.ReadLine()
let Ia = Array.init Q (fun _ -> stdin.ReadLine().Split() |> Array.map int |> fun x -> x.[0],x.[1],x.[2],x.[3])
solve N Q S Ia |> Array.iter stdout.WriteLine

solve 7 3 "abcbabc" [|(1,3,5,7);(1,5,2,6);(1,2,6,7)|] |> should equal [|"Yes";"No";"No"|]
