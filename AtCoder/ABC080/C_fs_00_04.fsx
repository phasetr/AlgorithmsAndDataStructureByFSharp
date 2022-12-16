#r "nuget: FsUnit"
open FsUnit

(*
let N,Fa,Pa = 1,[|[|1;1;0;1;0;0;0;1;0;1|]|],[|[|3;4;5;6;7;8;9;-2;-3;4;-2|]|]
let N,Fa,Pa = 2,[|[|1;1;1;1;1;0;0;0;0;0|];[|0;0;0;0;0;1;1;1;1;1|]|],[|[|0;-2;-2;-2;-2;-2;-1;-1;-1;-1;-1|];[|0;-2;-2;-2;-2;-2;-1;-1;-1;-1;-1|]|]
let N,Fa,Pa = 3,[|[|1;1;1;1;1;1;0;0;1;1|];[|0;1;0;1;1;1;1;0;1;0|];[|1;0;1;1;0;1;0;1;0;1|]|],[|[|-8;6;-2;-8;-8;4;8;7;-6;2;2|];[|-9;2;0;1;7;-5;0;-2;-6;5;5|];[|6;-6;7;-9;6;-5;8;0;-9;-7;-7|]|]
*)
let solve N (Fa:int[][]) (Pa:int[][]) =
  let cal opn f p = (0,opn,f) |||> Array.fold2 (fun acc o b -> if o=b && o=1 then acc+1 else acc) |> Array.get p
  (-System.Int32.MinValue, [|0..1023|])
  ||> Array.fold (fun acc n ->
    let opn = [|0..9|] |> Array.map (fun jk -> n>>>jk &&& 1)
    if Array.exists (fun i -> i=1) opn then max acc ((Fa,Pa) ||> Array.map2 (cal opn) |> Array.sum)
    else acc)

let N = stdin.ReadLine() |> int
let Fa = Array.init N (fun _ -> stdin.ReadLine().Split() |> Array.map int)
let Pa = Array.init N (fun _ -> stdin.ReadLine().Split() |> Array.map int)
solve N Fa Pa |> stdout.WriteLine

solve 1 [|[|1;1;0;1;0;0;0;1;0;1|]|] [|[|3;4;5;6;7;8;9;-2;-3;4;-2|]|] |> should equal 8
solve 2 [|[|1;1;1;1;1;0;0;0;0;0|];[|0;0;0;0;0;1;1;1;1;1|]|] [|[|0;-2;-2;-2;-2;-2;-1;-1;-1;-1;-1|];[|0;-2;-2;-2;-2;-2;-1;-1;-1;-1;-1|]|] |> should equal -2
solve 3 [|[|1;1;1;1;1;1;0;0;1;1|];[|0;1;0;1;1;1;1;0;1;0|];[|1;0;1;1;0;1;0;1;0;1|]|] [|[|-8;6;-2;-8;-8;4;8;7;-6;2;2|];[|-9;2;0;1;7;-5;0;-2;-6;5;5|];[|6;-6;7;-9;6;-5;8;0;-9;-7;-7|]|] |> should equal 23
