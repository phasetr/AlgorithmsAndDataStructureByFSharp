#r "nuget: FsUnit"
open FsUnit

(*
let N,Aa,Ba = 5,[|2;4;1;3|],[|5;3;3|]
let N,Aa,Ba = 10,[|1;19;75;37;17;16;33;18;22|],[|41;28;89;74;98;43;42;31|]
let N,Aa,Ba = 3,[|16;56|],[|67|]
let N,Aa,Ba = 5,[|13;45;14;45|],[|22;39;25|]
*)
let solve N (Aa:int[]) (Ba:int[]) =
  let memorec f =
    let memo = System.Collections.Generic.Dictionary<_,_>()
    let rec frec k =
      match memo.TryGetValue(k) with
        | true, v -> v
        | _ -> let v = f frec k in memo.Add(k,v); v
    frec
  let f frec k =
    if k=0 then ([1],0)
    elif k=1 then ([2;1],Aa.[0])
    else
      let (xs,x) = frec (k-1)
      let (ys,y) = frec (k-2)
      let (a,b) = (Aa.[k-1],Ba.[k-2])
      if y+b<x+a then ((k+1)::ys, y+b) else ((k+1)::xs, x+a)
  memorec f (N-1) |> (fst >> List.rev)
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
