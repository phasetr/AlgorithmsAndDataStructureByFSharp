#r "nuget: FsUnit"
open FsUnit

(*
let N = 127
let N = 3
let N = 44852
*)
let solve N =
  let array6 = Seq.initInfinite (fun i -> pown 6 i) |> Seq.takeWhile (fun x -> x<=N) |> Seq.toArray
  let array9 = Seq.initInfinite (fun i -> pown 9 i) |> Seq.takeWhile (fun x -> x<=N) |> Seq.toArray
  let memorec f =
    let memo = System.Collections.Generic.Dictionary<_,_>()
    let rec frec j =
      match memo.TryGetValue j with
        | exist, value when exist -> value
        | _ -> let value = f frec j in memo.Add(j, value); value
    frec
  let count frec n =
    if n=0 then 0
    else
      let c1 = n - (array6 |> Array.findBack (fun x -> x<=n))
      let c2 = n - (array9 |> Array.findBack (fun x -> x<=n))
      1 + min (frec c1) (frec c2)
  (memorec count) N

let N = stdin.ReadLine() |> int
solve N |> stdout.WriteLine

solve 127 |> should equal 4
solve 3 |> should equal 3
solve 44852 |> should equal 16
