#r "nuget: FsUnit"
open FsUnit

(*
let N,Fa,Pa = 1,[|[|1;1;0;1;0;0;0;1;0;1|]|],[|[|3;4;5;6;7;8;9;-2;-3;4;-2|]|]
let N,Fa,Pa = 2,[|[|1;1;1;1;1;0;0;0;0;0|];[|0;0;0;0;0;1;1;1;1;1|]|],[|[|0;-2;-2;-2;-2;-2;-1;-1;-1;-1;-1|];[|0;-2;-2;-2;-2;-2;-1;-1;-1;-1;-1|]|]
let N,Fa,Pa = 3,[|[|1;1;1;1;1;1;0;0;1;1|];[|0;1;0;1;1;1;1;0;1;0|];[|1;0;1;1;0;1;0;1;0;1|]|],[|[|-8;6;-2;-8;-8;4;8;7;-6;2;2|];[|-9;2;0;1;7;-5;0;-2;-6;5;5|];[|6;-6;7;-9;6;-5;8;0;-9;-7;-7|]|]
*)
// cf. https://atcoder.jp/contests/abc080/submissions/12061359
let solve N (Fa:int[][]) (Pa:int[][]) =
  let replicateM n xs =
    let k m acc = List.collect (fun y -> List.collect (fun ys -> [y::ys]) acc) m
    List.foldBack k (List.replicate n xs) [[]]
  let Oa = replicateM 10 [false;true] |> List.toArray |> Array.map (List.toArray)
  let Ga = Fa |> Array.map (Array.map ((=) 1))

  let cal opn g p = Array.map2 (&) opn g |> Array.sumBy (fun b -> if b then 1 else 0) |> Array.get p
  (System.Int32.MinValue, Oa)
  ||> Array.fold (fun acc opn ->
    if Array.exists id opn then max acc ((Ga, Pa) ||> Array.map2 (cal opn) |> Array.sum) else acc)

let N = stdin.ReadLine() |> int
let Fa = Array.init N (fun _ -> stdin.ReadLine().Split() |> Array.map int)
let Pa = Array.init N (fun _ -> stdin.ReadLine().Split() |> Array.map int)
solve N Fa Pa |> stdout.WriteLine

solve 1 [|[|1;1;0;1;0;0;0;1;0;1|]|] [|[|3;4;5;6;7;8;9;-2;-3;4;-2|]|] |> should equal 8
solve 2 [|[|1;1;1;1;1;0;0;0;0;0|];[|0;0;0;0;0;1;1;1;1;1|]|] [|[|0;-2;-2;-2;-2;-2;-1;-1;-1;-1;-1|];[|0;-2;-2;-2;-2;-2;-1;-1;-1;-1;-1|]|] |> should equal -2
solve 3 [|[|1;1;1;1;1;1;0;0;1;1|];[|0;1;0;1;1;1;1;0;1;0|];[|1;0;1;1;0;1;0;1;0;1|]|] [|[|-8;6;-2;-8;-8;4;8;7;-6;2;2|];[|-9;2;0;1;7;-5;0;-2;-6;5;5|];[|6;-6;7;-9;6;-5;8;0;-9;-7;-7|]|] |> should equal 23
