#r "nuget: FsUnit"
open FsUnit

(*
let Q,Qa = 3,[|[|1;2420|];[|1;1650|];[|2|]|]
*)
@"単純なリストによる実装: TLE"
let solveTLE Q (Qa:int[][]) =
  let rec enqueue x q =
    match x,q with
      | x,[] -> [x]
      | x,(e::q0) -> if x<=e then x::q else e::(enqueue x q0)
  let dequeue = function | [] -> failwith "dequeue: no element" | q -> (List.head q, List.tail q)
  let peek = function | [] -> failwith "peek: no element" | q -> List.head q
  ([],Qa) ||> Array.fold (fun q qa ->
    match qa.[0] with
      | 1 -> enqueue qa.[1] q
      | 2 -> q |> peek |> stdout.WriteLine; q
      | _ -> q |> dequeue |> snd)

let Q = stdin.ReadLine() |> int
let Qa = Array.init Q (fun _ -> stdin.ReadLine().Split() |> Array.map int)
solve Q Qa |> ignore

(*
1650
*)
