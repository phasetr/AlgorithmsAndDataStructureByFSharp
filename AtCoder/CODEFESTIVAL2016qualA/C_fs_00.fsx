#r "nuget: FsUnit"
open FsUnit

// let S,K = "xyz",4
let solve (S:string) K =
  let move k (c:char) = int c + k |> char
  let Ma = Array.map2 (fun c i -> (c,i%26)) [|'a'..'z'|] [|26..(-1)..1|] |> Map.ofArray
  let S0 = S.ToCharArray()
  let k,s = S0 |> Array.indexed |> fun s0 -> ((K,S0),s0) ||> Array.fold (fun (k,s) (i,c) ->
    let n = Ma.[c]
    if n<=k then Array.set s i 'a'; (k-n,s) else (k,s))
  if k=0 then s else let k0 = k%26 in (Array.set s (s.Length-1) (move k0 s.[s.Length-1]); s)
  |> System.String

let S = stdin.ReadLine()
let K = stdin.ReadLine() |> int
solve S K |> stdout.WriteLine

solve "xyz" 4 |> should equal "aya"
solve "a" 25 |> should equal "z"
solve "codefestival" 100 |> should equal "aaaafeaaivap"
