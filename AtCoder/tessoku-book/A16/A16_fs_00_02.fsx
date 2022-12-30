#r "nuget: FsUnit"
open FsUnit

(*
let N,Aa,Ba = 5,[|2;4;1;3|],[|5;3;7|]
let N,Aa,Ba = 10,[|1;19;75;37;17;16;33;18;22|],[|41;28;89;74;98;43;42;31|]
*)
let solveTLE N (Aa:int[]) (Ba:int[]) =
  let memorec f =
    let memo = Map.empty<_,_>
    let rec frec k =
      match memo |> Map.tryFind k with
        | Some v -> v
        | _ -> let v = f frec k in memo |> Map.add k v |> ignore; v
    frec
  let f frec k =
    if k<=0 then 0 elif k=1 then Aa.[k-1]
    else min (Aa.[k-1] + frec (k-1)) (Ba.[k-2] + frec (k-2))
  memorec f (N-1)

let solve N (Aa:int[]) (Ba:int[]) =
  let memorec f =
    let memo = System.Collections.Generic.Dictionary<_,_>()
    let rec frec j =
      match memo.TryGetValue j with
        | exist, value when exist -> value
        | _ -> let value = f frec j in memo.Add(j, value); value
    frec
  let f frec j =
    if j<=0 then 0 elif j=1 then Aa.[j-1]
    else min (Aa.[j-1] + frec (j-1)) (Ba.[j-2] + frec (j-2))
  memorec f (N-1)

let N = stdin.ReadLine() |> int
let Aa = stdin.ReadLine().Split() |> Array.map int
let Ba = stdin.ReadLine().Split() |> Array.map int
solve N Aa Ba |> stdout.WriteLine

solve 5 [|2;4;1;3|] [|5;3;7|] |> should equal 8
solve 10 [|1;19;75;37;17;16;33;18;22|] [|41;28;89;74;98;43;42;31|] |> should equal 157
