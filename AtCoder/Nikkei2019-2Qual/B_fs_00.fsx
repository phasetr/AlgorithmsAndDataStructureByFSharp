#r "nuget: FsUnit"
open FsUnit

let N,Da = 4,[|0;1;1;2|]
let solve N (Da:int[]) =
  let MOD = 998_244_353L
  let rec powmod x n = if n=0L then 1L else if n%2L=0L then powmod (x*x % MOD) (n/2L) else (x * (powmod x (n-1L)) % MOD)
  if Da.[0]<>0 then 0L
  else
    let ca = Da.[1..] |> Array.countBy id |> Array.sort
    if ca.Length <> (ca |> Array.last |> fst) then 0L
    else
      ca |> Array.map (snd >> int64)
      |> Array.fold (fun (pnum,acc) x -> (x, acc * (powmod pnum x) % MOD)) (1L,1L)
      |> snd

let N = stdin.ReadLine() |> int
let Da = stdin.ReadLine().Split() |> Array.map int
solve N Da |> stdout.WriteLine

solve 4 [|0;1;1;2|] |> should equal 2L
solve 4 [|1;1;1;1|] |> should equal 0L
solve 7 [|0;3;2;1;2;2;1|] |> should equal 24L
