#r "nuget: FsUnit"
open FsUnit

(*
let N,S,Aa = 3,7,[|2;2;3|]
let N,S,Aa = 3,10,[|1;2;4|]
let N,S,Aa = 10,100,[|14;23;18;7;11;23;23;5;8;2|]
*)
let solve N S (Aa:int[]) =
  let dp =
    Array2D.create (N+1) (S+1) false
    |> fun dp ->
      dp.[0,0] <- true
      for i in 1..N do
        for j in 0..S do
          if j<Aa.[i-1] then dp.[i,j] <- dp.[i-1,j]
          else dp.[i,j] <- dp.[i-1,j] || dp.[i-1,j-Aa.[i-1]]
      dp
  let rec frec acc i p =
    if i=0 then acc
    elif dp.[i-1,p] then frec acc (i-1) p
    else frec (i::acc) (i-1) (p-Aa.[i-1])
  if not dp.[N,S] then [] else frec [] N S

let N,S = stdin.ReadLine().Split() |> Array.map int |> (fun x -> x.[0],x.[1])
let Aa = stdin.ReadLine().Split() |> Array.map int
solve N S Aa |> function
  | [] -> stdout.WriteLine "-1"
  | l -> stdout.WriteLine l.Length; l |> List.map string |> String.concat " " |> stdout.WriteLine

solve 3 7 [|2;2;3|] |> should equal [1;2;3]
solve 3 10 [|1;2;4|] |> should equal (List.empty<int>)
solve 10 100 [|14;23;18;7;11;23;23;5;8;2|] |> should equal [2;3;6;7;8;9]
