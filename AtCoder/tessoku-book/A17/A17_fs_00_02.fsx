#r "nuget: FsUnit"
open FsUnit

(*
let N,Aa,Ba = 5,[|2;4;1;3|],[|5;3;3|]
let N,Aa,Ba = 10,[|1;19;75;37;17;16;33;18;22|],[|41;28;89;74;98;43;42;31|]
*)
let solve N (Aa:int[]) Ba =
  (Aa.[1..],Ba,[|3..N|])
  |||> Array.zip3
  |> fun Ta -> ((([2;1], Aa.[0]), ([1], 0)), Ta) ||> Array.fold (fun ((xs,x),(ys,y)) (a,b,i) ->
    ((if y+b<x+a then (i::ys, y+b) else (i::xs,x+a)), (xs,x)))
  |> (fst >> fst >> List.rev)
  |> fun Xs -> sprintf "%d\n%s" (Xs.Length) (Xs |> List.map string |> String.concat " ")

let N = stdin.ReadLine() |> int
let Aa = stdin.ReadLine().Split() |> Array.map int
let Ba = stdin.ReadLine().Split() |> Array.map int
solve N Aa Ba |> stdout.WriteLine

solve 5 [|2;4;1;3|] [|5;3;3|]
(*
4
1 2 4 5
*)
solve 10 [|1;19;75;37;17;16;33;18;22|] [|41;28;89;74;98;43;42;31|]
(*
7
1 2 4 5 6 8 10
*)
solve 3 [|16;56|] [|67|]
(*
2
1 3
*)
solve 5 [|13;45;14;45|] [|22;39;25|]
(*
3
1 3 5
*)
// small_03.txt
solve 4 [|6;45;72|] [|48;99|]
(*
3
1 2 4
*)
