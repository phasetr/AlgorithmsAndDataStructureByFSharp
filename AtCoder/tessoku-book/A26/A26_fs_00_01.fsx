#r "nuget: FsUnit"
open FsUnit

(*
let Q,Xa = 4,[|17;31;35;49|]
*)
let solve Q Xa =
  let sq = float >> sqrt >> int
  let isPrime x = if x=0||x=1 then false else let sqx = sq x in [|2..sqx|] |> Array.forall (fun n -> x%n<>0)
  [|0..100|] |> Array.map (fun x -> (x,isPrime x)) |> Array.filter (snd)
  Xa |> Array.map (fun x -> if isPrime x then "Yes" else "No")

let Q = stdin.ReadLine() |> int
let Xa = Array.init Q (fun _ -> stdin.ReadLine() |> int)
solve Q Xa |> Array.iter stdout.WriteLine

solve 4 [|17;31;35;49|] |> should equal [|"Yes";"Yes";"No";"No"|]

[|0..100|] |> Array.choose (fun x -> if isPrime x then Some x else None)
